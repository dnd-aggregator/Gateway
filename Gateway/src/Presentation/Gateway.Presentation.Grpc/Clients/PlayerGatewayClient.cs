using Gateway.Application.Contracts.Players;
using Gateway.Application.Models;
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

    public async Task PatchCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        var grpcRequest = new PatchCharacterGrpcRequest()
        {
            CharacterId = player.CharacterId,
            ScheduleId = player.ScheduleId,
            UserId = player.UserId,
        };

        await _playersGrpcClient.PatchCharacterAsync(grpcRequest);
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