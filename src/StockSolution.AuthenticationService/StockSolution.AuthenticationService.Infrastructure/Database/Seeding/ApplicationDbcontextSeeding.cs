using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Database.Seeding
{
    public static class ApplicationDbcontextSeeding
    {
        public static async Task Seeding(ApplicationDbcontext dbcontext)
        {
            // seeding role
            if (!dbcontext.Role.Any())
            {
                var admin = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                };
                var trader = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Trader",
                };
                dbcontext.Role.Add(admin);
                dbcontext.Role.Add(trader);
                await dbcontext.SaveChangesAsync();
            }
            // seeding user admin
            if (!dbcontext.User.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    CreatedAt = DateTime.UtcNow,
                    RoleId = await dbcontext.Role.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefaultAsync()
                };
                dbcontext.User.Add(user);
                await dbcontext.SaveChangesAsync();
            }
            // seeding permission
            if (!dbcontext.Permission.Any())
            {
                var permissions = new List<Permission>()
                {
                    new Permission() {  Name = "CreateUser" , Code ="user.create" ,Descrtiption ="Create a new user" },
                    new Permission() {  Name = "ReadUser" , Code ="user.read" ,Descrtiption ="Read user information" },
                    new Permission() { Name = "UpdateUser" , Code ="user.update" ,Descrtiption ="Update user information" },
                    new Permission() { Name = "UserDelete" , Code ="user.delete" ,Descrtiption ="Delete a user" },
                    new Permission() { Name = "StockView" , Code ="stock.view" ,Descrtiption ="View stock information" },
                    new Permission() {  Name = "StockBuy" , Code ="stock.buy" ,Descrtiption ="Buy stocks" },
                    new Permission() {  Name = "StockSell" , Code ="stock.sell" ,Descrtiption ="Sell stocks" },
                    new Permission() {  Name = "WalletView" , Code ="wallet.view" ,Descrtiption ="View wallet information" },
                    new Permission() {  Name = "WalletDeposit" , Code ="wallet.deposit" ,Descrtiption ="Deposit funds into wallet" },
                    new Permission() {  Name = "CreateRole" , Code ="role.create" ,Descrtiption ="Create a new role" },
                    new Permission() {  Name = "ReadRole" , Code ="role.read" ,Descrtiption ="Read role information" },
                    new Permission() {  Name = "UpdateRole" , Code ="role.update" ,Descrtiption ="Update role information" },
                    new Permission() {  Name = "DeleteRole" , Code ="role.delete" ,Descrtiption ="Delete a role" },
                };
                dbcontext.Permission.AddRange(permissions);
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}
