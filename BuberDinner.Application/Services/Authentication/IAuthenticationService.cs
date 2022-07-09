namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string email, string password, string firstName, string lastName);
    }
}
