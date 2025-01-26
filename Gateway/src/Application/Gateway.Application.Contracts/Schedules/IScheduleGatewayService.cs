using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Schedules;

public interface IScheduleGatewayService
{
    Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken);

    Task<ScheduleWithPlayersModel> GetSchedule(long id, CancellationToken cancellationToken);
}