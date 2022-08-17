using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstname, string lastname, string email, string password)
    {
        //Check if user already exists

        //Create a user(generate unique ID)

        // Create Jwt Token
        var userID = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userID, firstname, lastname);

        return new AuthenticationResult(
            userID, 
            firstname, 
            lastname, 
            email, 
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstname", 
            "lastname", 
            email, 
            "token");
    }
}