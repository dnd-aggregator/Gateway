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

    public async Task AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken)
    {
        await _playerGatewayClient.AddPlayer(player, cancellationToken);
    }
}