using Gateway.Application.Contracts.Characters;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("/gateway/characters")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterGatewayService _characterGatewayService;

    public CharacterController(ICharacterGatewayService characterGatewayService)
    {
        _characterGatewayService = characterGatewayService;
    }

    [HttpPost("{userId:long}")]
    public async Task<long> AddCharacter(long userId, AddCharacterRequest request, CancellationToken cancellationToken)
    {
        return await _characterGatewayService.AddCharacter(userId, request, cancellationToken);
    }

    [HttpGet]
    public async Task<CharacterGatewayModel> GetCharacter(long characterId, CancellationToken cancellationToken)
    {
        return await _characterGatewayService.GetCharacter(characterId, cancellationToken);
    }

    [HttpPatch("status")]
    public async Task<IActionResult> KillCharacter(PlayerGatewayModel player, CancellationToken cancellationToken)
    {
        KillResponse response = await _characterGatewayService.KillCharacter(player, cancellationToken);

        return response switch
        {
            KillResponse.KillResponseSuccess => new OkResult(),
            KillResponse.KillResponseFailure => new NotFoundResult(),
            _ => new ConflictResult(),
        };
    }

    [HttpPatch("weapon")]
    public async Task<IActionResult> AddWeapon(AddRequest request, CancellationToken cancellationToken)
    {
        AddResponse response = await _characterGatewayService.AddWeapon(request, cancellationToken);

        return response switch
        {
            AddResponse.AddResponseSuccess => new OkResult(),
            AddResponse.AddResponseFailure => new NotFoundResult(),
            _ => new ConflictResult(),
        };
    }

    [HttpPatch("gear")]
    public async Task<IActionResult> AddGear(AddRequest request, CancellationToken cancellationToken)
    {
        AddResponse response = await _characterGatewayService.AddGear(request, cancellationToken);

        return response switch
        {
            AddResponse.AddResponseSuccess => new OkResult(),
            AddResponse.AddResponseFailure => new NotFoundResult(),
            _ => new ConflictResult(),
        };
    }
}