using Gateway.Application.Characters;
using Gateway.Application.Contracts.Characters;
using Gateway.Application.Contracts.Games;
using Gateway.Application.Contracts.Players;
using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Contracts.Users;
using Gateway.Application.Games;
using Gateway.Application.Players;
using Gateway.Application.Schedules;
using Gateway.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IScheduleGatewayService, ScheduleGatewayService>();
        collection.AddScoped<IPlayerGatewayService, PlayerGatewayService>();
        collection.AddScoped<IUserGatewayService, UserGatewayService>();
        collection.AddScoped<ICharacterGatewayService, CharacterGatewayService>();
        collection.AddScoped<IGameGatewayService, GameGatewayService>();
        return collection;
    }
}