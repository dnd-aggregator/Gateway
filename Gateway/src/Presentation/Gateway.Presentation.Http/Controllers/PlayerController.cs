using Gateway.Application.Contracts.Players;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;
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
    public async Task<IActionResult> AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken)
    {
        AddPlayerResponse response = await _playerGatewayService.AddPlayer(player, cancellationToken);

        return response switch
        {
            AddPlayerResponse.AddPlayerSuccessResponse => new OkResult(),
            AddPlayerResponse.AddPlayerScheduleNotFoundResponse => new NotFoundObjectResult("Not found schedule"),
            AddPlayerResponse.AddPlayerUserNotFoundResponse => new NotFoundObjectResult("Not found user"),
            AddPlayerResponse.AddPlayerCharacterNotFoundResponse => new NotFoundObjectResult("Not found character"),
            _ => new ConflictResult(),
        };
    }

    [HttpPatch]
    public async Task<IActionResult> PatchCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        PatchPlayerCharacterResponse response = await _playerGatewayService.PatchCharacter(player, cancellationToken);

        return response switch
        {
            PatchPlayerCharacterResponse.PatchCharacterSuccessResponse => new OkResult(),
            PatchPlayerCharacterResponse.PatchCharacterScheduleNotFoundResponse => new NotFoundObjectResult(
                "Not found schedule"),
            PatchPlayerCharacterResponse.PatchCharacterUserNotFoundResponse => new NotFoundObjectResult(
                "Not found user"),
            PatchPlayerCharacterResponse.PatchCharacterCharacterNotFoundResponse => new NotFoundObjectResult(
                "Not found character"),
            _ => new ConflictResult(),
        };
    }

    [HttpDelete]
    public async Task DeletePlayer(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        await _playerGatewayService.DeletePlayer(player, cancellationToken);
    }
}