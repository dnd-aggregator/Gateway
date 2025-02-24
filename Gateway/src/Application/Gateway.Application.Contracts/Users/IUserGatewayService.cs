using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Users;

public interface IUserGatewayService
{
    Task<long> CreateUser(CreateUserGatewayRequest request, CancellationToken cancellationToken);

    Task<UserGatewayModel> GetUser(long userId, CancellationToken cancellationToken);
}