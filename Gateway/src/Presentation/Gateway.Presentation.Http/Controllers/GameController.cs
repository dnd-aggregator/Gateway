using Gateway.Application.Contracts.Games;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("/api/games")]
public class GameController : ControllerBase
{
    private readonly IGameGatewayService _gameService;

    public GameController(IGameGatewayService gameService)
    {
        _gameService = gameService;
    }

    [HttpPatch("{id:long}")]
    public async Task StartGame(long id, CancellationToken cancellationToken)
    {
        await _gameService.StartGame(id, cancellationToken);
    }

    [HttpPatch("{id:long}/status")]
    public async Task StopGame(long id, CancellationToken cancellationToken)
    {
        await _gameService.StopGame(id, cancellationToken);
    }
}