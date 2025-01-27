using Gateway.Application.Models;

namespace Gateway.Application.Contracts.Schedules;

public interface IScheduleGatewayClient
{
    Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken);

    Task<ScheduleGatewayModel> GetSchedule(long id, CancellationToken cancellationToken);

    Task<IEnumerable<ScheduleGatewayModel>> GetSchedules(GetSchedulesRequest request, CancellationToken cancellationToken);

    Task PatchScheduleStatus(long scheduleId, ScheduleStatus status, CancellationToken cancellationToken);
}