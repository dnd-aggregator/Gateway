using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Models;
using Google.Protobuf.WellKnownTypes;
using Schedules.Contracts;

namespace Gateway.Presentation.Grpc.Clients;

public class ScheduleGatewayClient : IScheduleGatewayClient
{
    private readonly ScheduleService.ScheduleServiceClient _scheduleServiceClient;

    public ScheduleGatewayClient(ScheduleService.ScheduleServiceClient scheduleServiceClient)
    {
        _scheduleServiceClient = scheduleServiceClient;
    }

    public async Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new CreateScheduleGrpcRequest()
        {
            MasterId = request.MasterId,
            Location = request.Location,
            Date = Timestamp.FromDateTime(request.Date),
        };

        CreateScheduleGrpcResponse result = await _scheduleServiceClient.CreateScheduleAsync(grpcRequest);

        return result.Id;
    }

    public async Task<ScheduleGatewayModel> GetSchedule(long id, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetScheduleGrpcRequest()
        {
            Id = id,
        };

        GetScheduleGrpcResponse grpcResponse = await _scheduleServiceClient.GetScheduleAsync(grpcRequest);

        var schedule = new ScheduleGatewayModel(
            grpcResponse.Response.Id,
            grpcResponse.Response.MasterId,
            grpcResponse.Response.Location,
            DateOnly.FromDateTime(grpcResponse.Response.Date.ToDateTime()));

        return schedule;
    }

    public async Task<IEnumerable<ScheduleGatewayModel>> GetSchedules(
        GetSchedulesRequest request,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new GetSchedulesGrpcRequest()
        {
            Ids = { request.Ids ?? [] },
            Location = request.Location ?? null,
            Date = Timestamp.FromDateTime(request.Date?.ToDateTime(TimeOnly.MinValue).ToUniversalTime() ?? DateTime.UtcNow),
            Cursor = request.Cursor,
            PageSize = request.PageSize,
        };

        GetSchedulesGrpcResponse schedulesGrpc = await _scheduleServiceClient.GetSchedulesAsync(grpcRequest);

        return schedulesGrpc.Response.Select(schedule => new ScheduleGatewayModel(
            schedule.Id,
            schedule.MasterId,
            schedule.Location,
            DateOnly.FromDateTime(schedule.Date.ToDateTime())));
    }
}