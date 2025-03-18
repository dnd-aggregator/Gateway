using Gateway.Application.Contracts.Characters;
using Gateway.Application.Models.Characters;

namespace Gateway.Application.Characters;

public class CharacterGatewayService : ICharacterGatewayService
{
    private readonly ICharacterGatewayClient _characterGatewayClient;

    public CharacterGatewayService(ICharacterGatewayClient characterGatewayClient)
    {
        _characterGatewayClient = characterGatewayClient;
    }

    public async Task<long> AddCharacter(long userId, AddCharacterRequest request, CancellationToken cancellationToken)
    {
        return await _characterGatewayClient.AddCharacter(userId, request, cancellationToken);
    }

    public async Task<CharacterGatewayModel> GetCharacter(long characterId, CancellationToken cancellationToken)
    {
        return await _characterGatewayClient.GetCharacter(characterId, cancellationToken);
    }
}