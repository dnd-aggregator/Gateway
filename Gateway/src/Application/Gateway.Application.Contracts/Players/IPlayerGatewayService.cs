using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Players;

public interface IPlayerGatewayService
{
    Task<AddPlayerResponse> AddPlayer(AddPlayerRequest player, CancellationToken cancellationToken);
}