namespace Gateway.Application.Models.Users;

public record CreateUserGatewayRequest(
    string Name,
    string PhoneNumber);