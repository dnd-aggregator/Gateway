using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Users;

public interface IUserGatewayClient
{
    Task<long> RegisterUser(CreateUserGatewayRequest request, CancellationToken cancellationToken);

    Task<UserGatewayModel> GetUser(long userId, CancellationToken cancellationToken);
}