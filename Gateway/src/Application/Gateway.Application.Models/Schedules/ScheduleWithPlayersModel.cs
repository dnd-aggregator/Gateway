using Gateway.Application.Models.Users;

namespace Gateway.Application.Models.Schedules;

public record ScheduleWithPlayersModel(
    ScheduleGatewayModel Schedule,
    IEnumerable<UserGatewayWithCharacterModel> Users);