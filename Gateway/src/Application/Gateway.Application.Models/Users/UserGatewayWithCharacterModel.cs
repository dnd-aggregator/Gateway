using Gateway.Application.Models.Characters;

namespace Gateway.Application.Models.Users;

public record UserGatewayWithCharacterModel(
    UserGatewayModel User,
    CharacterGatewayModel Character);