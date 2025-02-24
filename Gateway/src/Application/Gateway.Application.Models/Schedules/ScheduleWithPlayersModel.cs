using Gateway.Application.Models.Users;

namespace Gateway.Application.Models.Schedules;

public record ScheduleWithPlayersModel(
    long Id,
    UserGatewayModel Master,
    string Location,
    DateOnly Date,
    ScheduleStatus Status,
    IEnumerable<UserGatewayWithCharacterModel> Users);