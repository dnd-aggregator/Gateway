using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;

namespace Gateway.Application.Contracts.Characters;

public interface ICharacterGatewayClient
{
    Task<long> AddCharacter(long userId, AddCharacterRequest request, CancellationToken cancellationToken);

    Task<CharacterGatewayModel> GetCharacter(long characterId, CancellationToken cancellationToken);

    Task<KillResponse> KillCharacter(PlayerGatewayModel player, CancellationToken cancellationToken);

    Task<AddResponse> AddWeapon(AddRequest request, CancellationToken cancellationToken);

    Task<AddResponse> AddGear(AddRequest request, CancellationToken cancellationToken);
}