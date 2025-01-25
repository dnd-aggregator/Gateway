namespace Gateway.Application.Models;

public record CreateScheduleRequest(
    long MasterId,
    string Location,
    DateTime Date);