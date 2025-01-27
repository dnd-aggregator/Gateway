namespace Gateway.Application.Models.Characters;

public abstract record PatchPlayerCharacterResponse
{
    public sealed record PatchCharacterNoKnownResponse() : PatchPlayerCharacterResponse();

    public sealed record PatchCharacterSuccessResponse() : PatchPlayerCharacterResponse();

    public sealed record PatchCharacterScheduleNotFoundResponse() : PatchPlayerCharacterResponse();

    public sealed record PatchCharacterUserNotFoundResponse() : PatchPlayerCharacterResponse();

    public sealed record PatchCharacterCharacterNotFoundResponse() : PatchPlayerCharacterResponse();
}