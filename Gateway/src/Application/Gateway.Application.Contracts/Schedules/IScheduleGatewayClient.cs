using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Schedules;

public interface IScheduleGatewayClient
{
    Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken);

    Task<ScheduleGatewayModel> GetSchedule(long id, CancellationToken cancellationToken);
}