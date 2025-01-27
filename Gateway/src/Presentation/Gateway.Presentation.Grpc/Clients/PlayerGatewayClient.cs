using Gateway.Application.Contracts.Players;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;
using Schedules.Contracts;

namespace Gateway.Presentation.Grpc.Clients;

public class PlayerGatewayClient : IPlayerGatewayClient
{
    private readonly PlayersGrpcService.PlayersGrpcServiceClient _playersGrpcClient;

    public PlayerGatewayClient(PlayersGrpcService.PlayersGrpcServiceClient playersGrpcClient)
    {
        _playersGrpcClient = playersGrpcClient;
    }

    public async Task<IEnumerable<PlayerGatewayModel>> GetPlayersByScheduleId(
        long id,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new GetPlayersGrpcRequest()
        {
            ScheduleId = id,
        };

        GetPlayersGrpcResponse grpcPlayers = await _playersGrpcClient.GetPlayersByScheduleIdAsync(grpcRequest);

        IEnumerable<PlayerGatewayModel> players = grpcPlayers.Players.Select(player =>
            new PlayerGatewayModel(player.ScheduleId, player.UserId, player.CharacterId));

        return players;
    }

    public async Task<AddPlayerResponse> AddPlayer(AddPlayerRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new AddPlayerGrpcRequest()
        {
            Player = new PlayerGrpc()
            {
                ScheduleId = request.ScheduleId,
                UserId = request.UserId,
                CharacterId = request.CharacterId,
            },
        };

        AddPlayerGrpcResponse grpcResponse = await _playersGrpcClient.AddPlayerAsync(grpcRequest);

        return grpcResponse.ResultCase switch
        {
            AddPlayerGrpcResponse.ResultOneofCase.Success => new AddPlayerResponse.AddPlayerSuccessResponse(),
            AddPlayerGrpcResponse.ResultOneofCase.ScheduleNotFound =>
                new AddPlayerResponse.AddPlayerScheduleNotFoundResponse(),
            AddPlayerGrpcResponse.ResultOneofCase.UserNotFound => new AddPlayerResponse.AddPlayerUserNotFoundResponse(),
            AddPlayerGrpcResponse.ResultOneofCase.CharacterNotFound =>
                new AddPlayerResponse.AddPlayerCharacterNotFoundResponse(),
            AddPlayerGrpcResponse.ResultOneofCase.None => new AddPlayerResponse.AddPlayerUnknownResponse(),
            _ => new AddPlayerResponse.AddPlayerUnknownResponse(),
        };
    }

    public async Task<PatchPlayerCharacterResponse> PatchCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        var grpcRequest = new PatchCharacterGrpcRequest()
        {
            CharacterId = player.CharacterId,
            ScheduleId = player.ScheduleId,
            UserId = player.UserId,
        };

        PatchCharacterGrpcResponse response = await _playersGrpcClient.PatchCharacterAsync(grpcRequest);

        return response.ResultCase switch
        {
            PatchCharacterGrpcResponse.ResultOneofCase.Success =>
                new PatchPlayerCharacterResponse.PatchCharacterSuccessResponse(),
            PatchCharacterGrpcResponse.ResultOneofCase.ScheduleNotFound =>
                new PatchPlayerCharacterResponse.PatchCharacterScheduleNotFoundResponse(),
            PatchCharacterGrpcResponse.ResultOneofCase.UserNotFound =>
                new PatchPlayerCharacterResponse.PatchCharacterUserNotFoundResponse(),
            PatchCharacterGrpcResponse.ResultOneofCase.None =>
                new PatchPlayerCharacterResponse.PatchCharacterCharacterNotFoundResponse(),
            PatchCharacterGrpcResponse.ResultOneofCase.CharacterNotFound =>
                new PatchPlayerCharacterResponse.PatchCharacterNoKnownResponse(),
            _ => new PatchPlayerCharacterResponse.PatchCharacterNoKnownResponse(),
        };
    }

    public async Task DeletePlayer(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        var grpcRequest = new DeletePlayerGrpcRequest()
        {
            ScheduleId = player.ScheduleId,
            PayerId = player.UserId,
        };

        await _playersGrpcClient.DeletePlayerFromScheduleAsync(grpcRequest);
    }
}