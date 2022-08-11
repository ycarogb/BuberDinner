namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(
    Guid id,
    string FirstName,
    string LastName,
    string Email,
    string Token);