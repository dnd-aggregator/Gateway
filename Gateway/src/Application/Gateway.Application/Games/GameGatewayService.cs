using Gateway.Application.Contracts.Games;

namespace Gateway.Application.Games;

public class GameGatewayService : IGameGatewayService
{
    private readonly IGameGatewayClient _gameClient;

    public GameGatewayService(IGameGatewayClient gameClient)
    {
        _gameClient = gameClient;
    }

    public async Task StartGame(long id, CancellationToken cancellationToken)
    {
        await _gameClient.StartGame(id, cancellationToken);
    }

    public async Task StopGame(long id, CancellationToken cancellationToken)
    {
        await _gameClient.StopGame(id, cancellationToken);
    }
}