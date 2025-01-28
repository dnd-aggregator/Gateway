namespace Gateway.Application.Models.Characters;

public abstract record AddResponse
{
    public sealed record AddResponseSuccess() : AddResponse();

    public sealed record AddResponseFailure() : AddResponse();
}