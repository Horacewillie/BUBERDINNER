using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Domain.Entities;

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

            AuthenticationResponse? response = new (
                authRegisterResult.user.Id, 
                authRegisterResult.user.Email, 
                authRegisterResult.Token, 
                authRegisterResult.user.FirstName, 
                authRegisterResult.user.LastName);
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
                authLoginResult.user.Id,
                authLoginResult.user.Email,
                authLoginResult.Token,
                authLoginResult.user.FirstName,
                authLoginResult.user.LastName);
            return Ok(response);
        }
    }
}