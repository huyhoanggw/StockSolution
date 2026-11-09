using StockSolution.AuthenticationService.Domain.Entities;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Services.Interfaces
{
    public interface IRoleRepository : IGenericInterface<Role>
    {
    }
}
