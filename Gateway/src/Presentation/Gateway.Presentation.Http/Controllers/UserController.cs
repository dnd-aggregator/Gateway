using Gateway.Application.Contracts.Users;
using Gateway.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("/gateway/users")]
public class UserController : ControllerBase
{
    private readonly IUserGatewayService _userGatewayService;

    public UserController(IUserGatewayService userGatewayService)
    {
        _userGatewayService = userGatewayService;
    }

    [HttpPost]
    public async Task<long> AddUser(
        [FromBody] CreateUserGatewayRequest request,
        CancellationToken cancellationToken)
    {
        return await _userGatewayService.CreateUser(request, cancellationToken);
    }

    [HttpGet("{id:long}")]
    public async Task<UserGatewayModel> GetUserById(long id, CancellationToken cancellationToken)
    {
        return await _userGatewayService.GetUser(id, cancellationToken);
    }
}