// <copyright file="AddPlayerResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gateway.Application.Models;

public abstract record AddPlayerResponse
{
    public sealed record AddPlayerSuccessResponse() : AddPlayerResponse();

    public sealed record AddPlayerScheduleNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerUserNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerCharacterNotFoundResponse() : AddPlayerResponse();

    public sealed record AddPlayerUnknownResponse() : AddPlayerResponse();
}