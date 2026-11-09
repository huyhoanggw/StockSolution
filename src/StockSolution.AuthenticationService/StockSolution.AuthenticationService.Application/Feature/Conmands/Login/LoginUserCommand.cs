using MediatR;
using StockSolution.SharedLibrary.Dtos.User;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Feature.Conmands.Login
{
    public class LoginUserCommand : IRequest<ReponseResult<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
