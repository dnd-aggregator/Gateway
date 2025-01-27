namespace Gateway.Application.Models.Players;

public record PlayerGatewayModel(
    long ScheduleId,
    long UserId,
    long CharacterId);