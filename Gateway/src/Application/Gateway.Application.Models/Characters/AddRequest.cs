using Gateway.Application.Models.Players;

namespace Gateway.Application.Models.Characters;

public record AddRequest(
    PlayerGatewayModel Player,
    string CharacterBonus);