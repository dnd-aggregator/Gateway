namespace Gateway.Application.Models.Characters;

public abstract record KillResponse
{
    public sealed record KillResponseSuccess() : KillResponse();

    public sealed record KillResponseFailure() : KillResponse();
}