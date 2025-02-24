using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;

namespace Gateway.Application.Contracts.Players;

public interface IPlayerGatewayService
{
    Task<AddPlayerResponse> AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken);

    Task<PatchPlayerCharacterResponse> PatchCharacter(PlayerGatewayModel player, CancellationToken cancellationToken);

    Task DeletePlayer(PlayerGatewayModel player, CancellationToken cancellationToken);
}