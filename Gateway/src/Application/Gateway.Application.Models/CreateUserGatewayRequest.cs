namespace Gateway.Application.Models;

public record CreateUserGatewayRequest(
    string Name,
    string PhoneNumber);