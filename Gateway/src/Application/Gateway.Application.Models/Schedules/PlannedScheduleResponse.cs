namespace Gateway.Application.Models.Schedules;

public abstract record PlannedScheduleResponse()
{
    public sealed record PlannedScheduleNoKnown() : PlannedScheduleResponse();

    public sealed record PlannedScheduleSuccess() : PlannedScheduleResponse();

    public sealed record ScheduleNotFound() : PlannedScheduleResponse();

    public sealed record NotEnoughPlayers() : PlannedScheduleResponse();
}