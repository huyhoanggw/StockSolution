using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.AuthenticationService.Infrastructure.Database;
using StockSolution.SharedLibrary.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Repositories
{
    public class PermissionRepository : BaseRepositoryForSQL<Permission>, IPermissionRepository
    {
        ApplicationDbcontext _dbcontext;
        public PermissionRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<string>> GetUserPermissionsAsync(Guid UserId)
        {
            return await _dbcontext.UserRole.Where(x => x.UserId == UserId)
                .Join(_dbcontext.RolePermission,
                     us => us.RoleId,
                     rp => rp.RoleId,
                     (us, rp) => rp.PermissionId)
                .Join(_dbcontext.Permission,
                      permissionId => permissionId,
                      p => p.Id,
                      (permissionId, p) => p.Code).Distinct().ToListAsync();
        }
    }
}
