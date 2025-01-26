namespace Gateway.Application.Models;

public record UserGatewayWithCharacterModel(
    UserGatewayModel User,
    CharacterGatewayModel Character);