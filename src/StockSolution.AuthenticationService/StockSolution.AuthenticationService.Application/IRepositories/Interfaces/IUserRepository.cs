using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.SharedLibrary.Dtos.User;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Services.Interfaces
{
    public interface IUserRepository : IGenericInterface<User>
    {
        Task<string> Login(UserLogin user);
        Task<bool> Register(string username, string email, string password);
    }
}
