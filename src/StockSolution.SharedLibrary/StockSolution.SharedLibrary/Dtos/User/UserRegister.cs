using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Dtos.User
{
    public record UserRegister
         (
            string UserName,
            string Email,
            string Password
         );
}
