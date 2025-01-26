using Gateway.Application.Contracts.Players;
using Gateway.Application.Models;

namespace Gateway.Application.Players;

public class PlayerGatewayService : IPlayerGatewayService
{
    private readonly IPlayerGatewayClient _playerGatewayClient;

    public PlayerGatewayService(IPlayerGatewayClient playerGatewayClient)
    {
        _playerGatewayClient = playerGatewayClient;
    }

    public async Task<AddPlayerResponse> AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken)
    {
        return await _playerGatewayClient.AddPlayer(player, cancellationToken);
    }
}