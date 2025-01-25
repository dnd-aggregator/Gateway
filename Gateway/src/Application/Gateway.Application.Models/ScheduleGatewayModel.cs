namespace Gateway.Application.Models;

public record ScheduleGatewayModel(
    long Id,
    long MasterId,
    string Location,
    DateOnly Date);