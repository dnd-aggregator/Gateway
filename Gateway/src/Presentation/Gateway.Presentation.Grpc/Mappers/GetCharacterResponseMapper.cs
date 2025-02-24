using CharactersGrpc.Proto;
using Gateway.Application.Models.Characters;

namespace Gateway.Presentation.Grpc.Mappers;

public static class GetCharacterResponseMapper
{
    public static CharacterGatewayModel MapToDomainModel(this GetCharacterResponse grpcResponse)
    {
        CharacterModel character = grpcResponse.Character;

        return new CharacterGatewayModel(
            characterName: character.CharacterName,
            characterDescription: character.CharacterDescription,
            characterLevel: character.CharacterLevel,
            race: character.Race,
            worldView: character.WorldView,
            speed: character.Speed,
            defence: character.Defence,
            health: character.Health,
            maxHealth: character.MaxHealth,
            strenth: character.Strength,
            dexterity: character.Dexterity,
            endurance: character.Endurance,
            intelligence: character.Intelligence,
            wisdom: character.Wisdom,
            bonus: character.Bonus,
            gear: character.Gear,
            weapons: character.Weapons,
            personalityTraits: character.PersonalityTraits,
            ideals: character.Ideals,
            bonds: character.Bonds,
            flaws: character.Flaws,
            history: character.History,
            activeSkills: character.ActiveSkills,
            passiveSkills: character.PassiveSkills,
            userId: character.UserId)
        {
            CharacterId = character.CharacterId,
            Status = MapCharacterStatus(character.Status),
        };
    }

    private static CharacterStatus MapCharacterStatus(string grpcStatus)
    {
        return grpcStatus switch
        {
            "Draft" => CharacterStatus.Draft,
            "Alive" => CharacterStatus.Alive,
            "Dead" => CharacterStatus.Dead,
            "Missing" => CharacterStatus.Missing,
            _ => throw new ArgumentException($"Unknown status: {grpcStatus}"),
        };
    }
}
