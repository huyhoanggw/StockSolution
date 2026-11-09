using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.AuthenticationService.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Helpers
{
    public class AddPermissionToRole
    {
        public static async Task Add(Guid RoleId, string PermissionCode, ApplicationDbcontext dbcontext)
        {
            var role = await dbcontext.Role.Where(x => x.Id == RoleId).FirstOrDefaultAsync();
            var permission = await dbcontext.Permission.Where(x => x.Code == PermissionCode).FirstOrDefaultAsync();
            var existsPermissionRole = await dbcontext.RolePermission.Where(x => x.RoleId == role.Id && x.PermissionId == permission.Id).FirstOrDefaultAsync();
            if (existsPermissionRole != null)
            {
                throw new Exception("Permission already exists for this role");
            }
            var rolePermission = new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permission.Id
            };
            await dbcontext.RolePermission.AddAsync(rolePermission);
            await dbcontext.SaveChangesAsync();
        }
    }
}
