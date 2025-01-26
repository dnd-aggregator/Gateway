using CharactersGrpc.Proto;
using Gateway.Application.Contracts.Characters;
using Gateway.Application.Models;
using Gateway.Presentation.Grpc.Mappers;

namespace Gateway.Presentation.Grpc.Clients;

public class CharacterGatewayClient : ICharacterGatewayClient
{
    private readonly CharacterService.CharacterServiceClient _characterServiceClient;

    public CharacterGatewayClient(CharacterService.CharacterServiceClient characterServiceClient)
    {
        _characterServiceClient = characterServiceClient;
    }

    public async Task<long> AddCharacter(long userId, AddCharacterRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new RegisterCharacterRequest
        {
            CharacterName = request.CharacterName,
            CharacterDescription = request.CharacterDescription,
            CharacterLevel = request.CharacterLevel,
            Race = request.Race,
            WorldView = request.WorldView,
            Speed = request.Speed,
            Defence = request.Defence,
            Health = request.Health,
            MaxHealth = request.MaxHealth,
            Strength = request.Strenth,
            Dexterity = request.Dexterity,
            Endurance = request.Endurance,
            Intelligence = request.Intelligence,
            Wisdom = request.Wisdom,
            Bonus = request.Bonus,
            Gear = { request.Gear },
            Weapons = { request.Weapons },
            PersonalityTraits = request.PersonalityTraits,
            Ideals = request.Ideals,
            Bonds = request.Bonds,
            Flaws = request.Flaws,
            History = request.History,
            ActiveSkills = { request.ActiveSkills },
            PassiveSkills = { request.PassiveSkills },
            UserId = userId,
        };

        RegisterCharacterResponse grpcResult = await _characterServiceClient.RegisterCharacterAsync(grpcRequest);

        return grpcResult.CharacterId;
    }

    public async Task<CharacterGatewayModel> GetCharacter(long characterId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetCharacterRequest() { CharacterId = characterId };

        GetCharacterResponse grpcCharacter = await _characterServiceClient.GetCharacterAsync(grpcRequest);

        CharacterGatewayModel character = grpcCharacter.MapToDomainModel();

        return character;
    }
}