using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;


namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstname, string lastname, string email, string password)
    {
        //1. Validate tha user doesn't exists
        if(_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User with the given email already exists.");
        }

        //2. Create user (generate unique ID)
        var user = new User
        {
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //3. Create Jwt Token
        var userID = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstname, lastname);

        return new AuthenticationResult(
            user.Id, 
            firstname, 
            lastname, 
            email, 
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);   
        //1. Validate user exists
        if (user == null)
        {
            throw new Exception("User with given email does not exist.");
        }
        else
        {
            //2. Validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }
            else
            {
                //3. Create Jwt
                var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

                return new AuthenticationResult(
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    email,
                    "token");
            }
        }
    }
}