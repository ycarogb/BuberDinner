namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Register(string firstname, string lastname, string email, string password);

    public AuthenticationResult Login(string email, string password);
}