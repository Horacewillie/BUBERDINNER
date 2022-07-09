using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Api.Controllers
{
   
    
    
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authRegisterResult = _authenticationService.Register(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName);
            var response = new AuthenticationResponse(
                authRegisterResult.Id,
                authRegisterResult.Email,
                authRegisterResult.Token,
                authRegisterResult.FirstName,
                authRegisterResult.LastName);
            return Ok(response);
        }


        [HttpPost]
        [Route("login")]
        public  IActionResult Login(LoginRequest request)
        {
            var authLoginResult = _authenticationService.Login(
                request.Email,
                request.Password);

             var response = new AuthenticationResponse(
                authLoginResult.Id,
                authLoginResult.Email,
                authLoginResult.Token,
                authLoginResult.FirstName,
                authLoginResult.LastName);
            return Ok(response);
        }
    }
}