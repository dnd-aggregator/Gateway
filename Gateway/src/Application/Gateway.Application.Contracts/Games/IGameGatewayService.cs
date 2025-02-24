namespace Gateway.Application.Contracts.Games;

public interface IGameGatewayService
{
    Task StartGame(long id, CancellationToken cancellationToken);

    Task StopGame(long id, CancellationToken cancellationToken);
}