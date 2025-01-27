namespace Gateway.Application.Contracts.Games;

public interface IGameGatewayClient
{
    Task StartGame(long id, CancellationToken cancellationToken);

    Task StopGame(long id, CancellationToken cancellationToken);
}