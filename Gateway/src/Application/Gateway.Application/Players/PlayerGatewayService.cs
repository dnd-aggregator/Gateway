using Gateway.Application.Contracts.Players;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;

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

    public async Task<PatchPlayerCharacterResponse> PatchCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        return await _playerGatewayClient.PatchCharacter(player, cancellationToken);
    }

    public async Task DeletePlayer(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        await _playerGatewayClient.DeletePlayer(player, cancellationToken);
    }
}