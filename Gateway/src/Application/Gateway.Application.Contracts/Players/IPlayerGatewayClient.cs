using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Players;

public interface IPlayerGatewayClient
{
    Task<IEnumerable<PlayerGatewayModel>> GetPlayersByScheduleId(long id, CancellationToken cancellationToken);

    Task<AddPlayerResponse> AddPlayer(AddPlayerRequest request, CancellationToken cancellationToken);
}