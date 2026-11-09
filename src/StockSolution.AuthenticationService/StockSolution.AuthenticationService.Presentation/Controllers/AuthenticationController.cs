using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockSolution.AuthenticationService.Application.Feature.Conmands.Login;
using StockSolution.AuthenticationService.Application.Feature.Conmands.Register;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.SharedLibrary.Dtos.User;

namespace StockSolution.AuthenticationService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IMediator _mediar) : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin request)
        {
            var result = await _mediar.Send(new LoginUserCommand() { Email = request.Email, Password = request.Password });
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
        {
            var result = await _mediar.Send(new RegisterUserCommand() { Email = request.Email, Password = request.Password, UserName = request.UserName });
            return Ok(result);
        }
    }
}
