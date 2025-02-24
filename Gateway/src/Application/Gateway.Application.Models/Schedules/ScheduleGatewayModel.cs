namespace Gateway.Application.Models.Schedules;

public record ScheduleGatewayModel(
    long Id,
    long MasterId,
    string Location,
    DateOnly Date,
    ScheduleStatus Status);