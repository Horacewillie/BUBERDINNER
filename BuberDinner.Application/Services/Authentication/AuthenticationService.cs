using System;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            //Validate email and password field
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(email), "Email and password are required");
            }

               //Validate existence of User
            if(_userRepository.GetByEmail(email) is not User user){
                throw new Exception("User not found");
            }

              //Validate password
            if(user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }
         
            //Create Token
            var token = _jwtTokenGenerator.GenerateToken(user);
          
            return new AuthenticationResult(
                user,
                token
               );
        }

        public AuthenticationResult Register(string email, string password, string firstName, string lastName)
        {
            if(_userRepository.GetByEmail(email) is not null)
            {
                throw new Exception("User with this email already exists.");
            }
            var user = new User 
            { 
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };
            //Console.WriteLine(JsonConvert.SerializeObject(user));

            _userRepository.AddUser(user);
            
            var token = _jwtTokenGenerator.GenerateToken(user);
            
                return new AuthenticationResult(
                  user,
                  token);
            }
    }
}