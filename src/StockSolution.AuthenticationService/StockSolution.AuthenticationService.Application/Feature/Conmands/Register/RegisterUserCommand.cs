using MediatR;
using StockSolution.SharedLibrary.Dtos.User;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Feature.Conmands.Register
{
    public class RegisterUserCommand : IRequest<ReponseResult<UserRegister>>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

