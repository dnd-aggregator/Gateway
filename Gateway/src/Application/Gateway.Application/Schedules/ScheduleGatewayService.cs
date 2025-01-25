using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Models;

namespace Gateway.Application.Schedules;

public class ScheduleGatewayService : IScheduleGatewayService
{
    private readonly IScheduleGatewayClient _scheduleGatewayClient;

    public ScheduleGatewayService(IScheduleGatewayClient scheduleGatewayClient)
    {
        _scheduleGatewayClient = scheduleGatewayClient;
    }

    public async Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayClient.CreateSchedule(request, cancellationToken);
    }

    public async Task<ScheduleGatewayModel> GetSchedule(long id, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayClient.GetSchedule(id, cancellationToken);
    }
}