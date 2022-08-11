namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(
    string Email,
    string Password);