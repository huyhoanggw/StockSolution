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
    public static class AddPermissionForAdmin
    {
        public static async Task AddAsync(ApplicationDbcontext dbcontext)
        {
            var role = await dbcontext.Role.Where(x => x.Name == "Admin").Select(x => x.Id).FirstOrDefaultAsync();
            if (!dbcontext.RolePermission.Any(x => x.RoleId == role))
            {
                var permissions = await dbcontext.Permission.ToListAsync();
                foreach (var permission in permissions)
                {
                    await AddPermissionToRole.Add(role, permission.Code, dbcontext);
                }
            }

        }

    }
}
