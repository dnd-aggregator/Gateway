using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Schedules;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IScheduleGatewayService, ScheduleGatewayService>();
        return collection;
    }
}