using Itmo.Dev.Platform.BackgroundTasks.Configuration;

namespace Gateway.Application.Extensions;

public static class BackgroundTaskConfigurationExtensions
{
    public static IBackgroundTaskConfigurationBuilder AddApplicationBackgroundTasks(
        this IBackgroundTaskStateMachineConfigurator builder)
    {
        // TODO: register background tasks via AddBackgroundTask extension method
        return builder;
    }
}