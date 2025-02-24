namespace Gateway.Application.Models.Players;

public abstract record AddPlayerResponse
{
    public sealed record AddPlayerSuccessResponse() : AddPlayerResponse();

    public sealed record AddPlayerScheduleNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerUserNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerCharacterNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerUnknownResponse() : AddPlayerResponse();
}