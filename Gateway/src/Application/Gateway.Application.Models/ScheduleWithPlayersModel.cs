namespace Gateway.Application.Models;

public record ScheduleWithPlayersModel(
    ScheduleGatewayModel Schedule,
    IEnumerable<UserGatewayWithCharacterModel> Users);