namespace Gateway.Application.Models.Schedules;

public record CreateScheduleRequest(
    long MasterId,
    string Location,
    DateTime Date);