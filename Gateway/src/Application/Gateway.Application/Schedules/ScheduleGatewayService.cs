using Gateway.Application.Contracts.Players;
using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Models;

namespace Gateway.Application.Schedules;

public class ScheduleGatewayService : IScheduleGatewayService
{
    private readonly IScheduleGatewayClient _scheduleGatewayClient;
    private readonly IPlayerGatewayClient _playerGatewayClient;

    public ScheduleGatewayService(
        IScheduleGatewayClient scheduleGatewayClient,
        IPlayerGatewayClient playerGatewayClient)
    {
        _scheduleGatewayClient = scheduleGatewayClient;
        _playerGatewayClient = playerGatewayClient;
    }

    public async Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayClient.CreateSchedule(request, cancellationToken);
    }

    public async Task<ScheduleWithPlayersModel> GetSchedule(long id, CancellationToken cancellationToken)
    {
        ScheduleGatewayModel schedule = await _scheduleGatewayClient.GetSchedule(id, cancellationToken);

        IEnumerable<PlayerGatewayModel> players =
            await _playerGatewayClient.GetPlayersByScheduleId(schedule.Id, cancellationToken);

        return new ScheduleWithPlayersModel(
            schedule.Id,
            schedule.MasterId,
            schedule.Location,
            schedule.Date,
            players);
    }
}