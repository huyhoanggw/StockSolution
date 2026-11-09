using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Application.IRepositories.Interfaces;
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
    public class UserRoleRepository : BaseRepositoryForSQL<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
