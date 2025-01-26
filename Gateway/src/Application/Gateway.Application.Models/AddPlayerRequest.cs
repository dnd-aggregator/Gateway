namespace Gateway.Application.Models;

public record AddPlayerRequest(
    long ScheduleId,
    long UserId,
    long CharacterId);