namespace Gateway.Application.Models;

public record GetSchedulesRequest(
    long[]? Ids = null,
    string? Location = null,
    DateOnly? Date = null,
    long Cursor = 0,
    int PageSize = int.MaxValue);