using Gateway.Application.Contracts.Players;
using Gateway.Application.Contracts.Schedules;
using Gateway.Presentation.Grpc.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Presentation.Grpc.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationGrpc(this IServiceCollection collection)
    {
        collection.AddGrpc();
        collection.AddGrpcReflection();
        collection.AddScoped<IScheduleGatewayClient, ScheduleGatewayClient>();
        collection.AddScoped<IPlayerGatewayClient, PlayerGatewayClient>();

        return collection;
    }
}