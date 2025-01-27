using Game;
using Gateway.Application.Contracts.Games;

namespace Gateway.Presentation.Grpc.Clients;

public class GameGatewayClient : IGameGatewayClient
{
    private readonly GameStatusService.GameStatusServiceClient _gameStatusService;

    public GameGatewayClient(GameStatusService.GameStatusServiceClient gameStatusService)
    {
        _gameStatusService = gameStatusService;
    }

    public async Task StartGame(long id, CancellationToken cancellationToken)
    {
        var grpcRequest = new StartGameRequest()
        {
            GameId = id,
        };

        await _gameStatusService.StartGameAsync(grpcRequest);
    }

    public async Task StopGame(long id, CancellationToken cancellationToken)
    {
        var grpcRequest = new FinishGameRequest()
        {
            GameId = id,
        };

        await _gameStatusService.FinishGameAsync(grpcRequest);
    }
}