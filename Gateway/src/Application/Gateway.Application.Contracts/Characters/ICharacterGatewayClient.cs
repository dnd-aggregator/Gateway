using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Characters;

public interface ICharacterGatewayClient
{
    Task<long> AddCharacter(long userId, AddCharacterRequest request, CancellationToken cancellationToken);

    Task<CharacterGatewayModel> GetCharacter(long characterId, CancellationToken cancellationToken);
}