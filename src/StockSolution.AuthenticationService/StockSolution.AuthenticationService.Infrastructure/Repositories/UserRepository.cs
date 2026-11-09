using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.AuthenticationService.Infrastructure.Database;
using StockSolution.SharedLibrary.BaseRepository;
using StockSolution.SharedLibrary.Dtos.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Repositories
{
    public class UserRepository : BaseRepositoryForSQL<User>, IUserRepository
    {
        public ApplicationDbcontext _dbcontext;
        private readonly IConfiguration _config;

        public UserRepository(ApplicationDbcontext dbcontext, IConfiguration config) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _config = config;
        }

        public async Task<string> GenerateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value!);
            var issuer = _config.GetSection("JWT:Issuer").Value;
            var audience = _config.GetSection("JWT:Audience").Value;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            if (user.RoleId != null)
            {
                var role = await _dbcontext.Role.Where(x => x.Id == user.RoleId).FirstOrDefaultAsync();
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            var permissions = await _dbcontext.UserRole.Where(x => x.UserId == user.Id)
                                .Join(_dbcontext.RolePermission,
                                     ur => ur.RoleId,
                                     rp => rp.RoleId,
                                     (ur, rp) => rp.PermissionId).
                                Join(_dbcontext.Permission,
                                     permissionId => permissionId,
                                     p => p.Id,
                                     (permissionId, p) => p.Code
                                     ).Distinct().ToListAsync();
            foreach (var i in permissions)
            {
                claims.Add(new Claim("permission", i));
            }
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Login(UserLogin user)
        {
            var getUser = await _dbcontext.User.Where(x => x.Email.Equals(user.Email)).FirstOrDefaultAsync();
            var verifyPass = BCrypt.Net.BCrypt.Verify(user.Password, getUser.PasswordHash);
            if (!verifyPass) return null;
            var token = GenerateToken(getUser);
            return await token;

        }

        public async Task<bool> Register(string username, string email, string password)
        {
            User add = new User()
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            var roleId = await _dbcontext.Role.Where(x => x.Name.Equals("Trader")).Select(x => x.Id).FirstOrDefaultAsync();
            add.RoleId = roleId;
            UserRole userRole = new UserRole()
            {
                RoleId = roleId,
                UserId = add.Id
            };
            await _dbcontext.User.AddAsync(add);
            await _dbcontext.UserRole.AddAsync(userRole);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
