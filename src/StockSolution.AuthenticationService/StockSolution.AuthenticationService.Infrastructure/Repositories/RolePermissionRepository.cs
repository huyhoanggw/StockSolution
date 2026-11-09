using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.AuthenticationService.Infrastructure.Database;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.SharedLibrary.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Repositories
{
    public class RolePermissionRepository : BaseRepositoryForSQL<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
