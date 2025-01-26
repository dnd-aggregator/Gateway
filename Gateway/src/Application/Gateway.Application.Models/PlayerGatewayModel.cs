namespace Gateway.Application.Models;

public record PlayerGatewayModel(
    long ScheduleId,
    long UserId,
    long CharacterId);