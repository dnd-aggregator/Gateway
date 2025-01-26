using Gateway.Application.Contracts.Players;
using Gateway.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("/gateway/players")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerGatewayService _playerGatewayService;

    public PlayerController(IPlayerGatewayService playerGatewayService)
    {
        _playerGatewayService = playerGatewayService;
    }

    [HttpPost]
    public async Task AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken)
    {
        await _playerGatewayService.AddPlayer(player, cancellationToken);
    }
}