using MediatR;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.SharedLibrary.Dtos.User;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Feature.Conmands.Login
{
    public class LoginUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LoginUserCommand, ReponseResult<string>>
    {
        public async Task<ReponseResult<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var existEmail = await userRepository.GetByAsync(x => x.Email == request.Email);
            if (existEmail is null) return new ReponseError<string>("Email not found , please register");

            var result = await userRepository.Login(new UserLogin(request.Email, request.Password));
            if (string.IsNullOrEmpty(result)) return new ReponseError<string>("Email or password is incorrect");

            return new ReponseSuccess<string>(result, "Login successful");
        }
    }
}
