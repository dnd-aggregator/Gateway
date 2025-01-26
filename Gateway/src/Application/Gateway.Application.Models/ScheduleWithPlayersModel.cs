namespace Gateway.Application.Models;

public record ScheduleWithPlayersModel(
    long Id,
    long MasterId,
    string Location,
    DateOnly Date,
    IEnumerable<UserGatewayWithCharacterModel> Users);