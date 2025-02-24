using Gateway.Application.Contracts.Users;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Users;

public class UserGatewayService : IUserGatewayService
{
    private readonly IUserGatewayClient _userGatewayClient;

    public UserGatewayService(IUserGatewayClient userGatewayClient)
    {
        _userGatewayClient = userGatewayClient;
    }

    public async Task<long> CreateUser(CreateUserGatewayRequest request, CancellationToken cancellationToken)
    {
        return await _userGatewayClient.RegisterUser(request, cancellationToken);
    }

    public async Task<UserGatewayModel> GetUser(long userId, CancellationToken cancellationToken)
    {
        return await _userGatewayClient.GetUser(userId, cancellationToken);
    }
}