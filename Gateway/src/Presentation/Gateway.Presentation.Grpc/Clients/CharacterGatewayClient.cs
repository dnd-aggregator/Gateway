using CharactersGrpc.Proto;
using Gateway.Application.Contracts.Characters;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;
using Gateway.Presentation.Grpc.Mappers;

namespace Gateway.Presentation.Grpc.Clients;

public class CharacterGatewayClient : ICharacterGatewayClient
{
    private readonly CharacterService.CharacterServiceClient _characterServiceClient;
    private readonly CharacterStatusService.CharacterStatusServiceClient _characterStatusService;

    public CharacterGatewayClient(
        CharacterService.CharacterServiceClient characterServiceClient,
        CharacterStatusService.CharacterStatusServiceClient characterStatusService)
    {
        _characterServiceClient = characterServiceClient;
        _characterStatusService = characterStatusService;
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

    public async Task<KillResponse> KillCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        var grpcRequest = new KillCharacterRequest()
        {
            CharacterId = player.CharacterId,
            GameId = player.ScheduleId,
        };

        KillCharacterResponse response = await _characterStatusService.KillCharacterAsync(grpcRequest);

        return response.ResultCase switch
        {
            KillCharacterResponse.ResultOneofCase.None => new KillResponse.KillResponseFailure(),
            KillCharacterResponse.ResultOneofCase.Success => new KillResponse.KillResponseSuccess(),
            KillCharacterResponse.ResultOneofCase.NotFound => new KillResponse.KillResponseFailure(),
            _ => new KillResponse.KillResponseFailure(),
        };
    }

    public async Task<AddResponse> AddWeapon(AddRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new AddWeaponRequest()
        {
            CharacterId = request.Player.CharacterId,
            GameId = request.Player.ScheduleId,
            Weapon = request.CharacterBonus,
        };

        AddWeaponResponse grpcResponse = await _characterStatusService.AddWeaponAsync(grpcRequest);

        return grpcResponse.ResultCase switch
        {
            AddWeaponResponse.ResultOneofCase.None => new AddResponse.AddResponseFailure(),
            AddWeaponResponse.ResultOneofCase.Success => new AddResponse.AddResponseSuccess(),
            AddWeaponResponse.ResultOneofCase.NotFound => new AddResponse.AddResponseFailure(),
            _ => new AddResponse.AddResponseFailure(),
        };
    }

    public async Task<AddResponse> AddGear(AddRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new AddGearRequest()
        {
            CharacterId = request.Player.CharacterId,
            GameId = request.Player.ScheduleId,
            Gear = request.CharacterBonus,
        };

        AddGearResponse response = await _characterStatusService.AddGearAsync(grpcRequest);

        return response.ResultCase switch
        {
            AddGearResponse.ResultOneofCase.None => new AddResponse.AddResponseFailure(),
            AddGearResponse.ResultOneofCase.Success => new AddResponse.AddResponseSuccess(),
            AddGearResponse.ResultOneofCase.NotFound => new AddResponse.AddResponseFailure(),
            _ => new AddResponse.AddResponseFailure(),
        };
    }
}