using Gateway.Application.Contracts.Characters;
using Gateway.Application.Models.Characters;
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
}