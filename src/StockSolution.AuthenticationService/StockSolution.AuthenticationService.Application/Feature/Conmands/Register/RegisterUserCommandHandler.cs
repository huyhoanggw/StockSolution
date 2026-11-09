using MediatR;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.SharedLibrary.Dtos.User;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Application.Feature.Conmands.Register
{
    public class RegisterUserCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, ReponseResult<UserRegister>>
    {

        async Task<ReponseResult<UserRegister>> IRequestHandler<RegisterUserCommand, ReponseResult<UserRegister>>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existUsername = await userRepository.GetByAsync(x => x.UserName.Equals(request.UserName));
            var existEmail = await userRepository.GetByAsync(x => x.Email.Equals(request.Email));
            if (existEmail is not null) return new ReponseError<UserRegister>("Email already exists");
            if (existUsername is not null) return new ReponseError<UserRegister>("Username already exists");
            var result = await userRepository.Register(request.UserName, request.Email, request.Password);
            return result == true ? new ReponseSuccess<UserRegister>("User registered successfully") : new ReponseError<UserRegister>("Failed to register user");
        }
    }
}
