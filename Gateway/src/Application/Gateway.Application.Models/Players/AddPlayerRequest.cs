namespace Gateway.Application.Models.Players;

public record AddPlayerRequest(
    long ScheduleId,
    long UserId,
    long CharacterId);