#pragma warning disable CA1506

using Character.Validation;
using CharactersGrpc.Proto;
using Game;
using Gateway.Application.Extensions;
using Gateway.Presentation.Grpc.Extensions;
using Gateway.Presentation.Http.Extensions;
using Gateway.Presentation.Kafka.Extensions;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Events;
using Itmo.Dev.Platform.Observability;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Schedules.Contracts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddPlatform();
builder.AddPlatformObservability();

builder.Services.AddApplication();

// builder.Services.AddInfrastructurePersistence();
builder.Services.AddPresentationGrpc();

builder.Services.AddGrpcClient<ScheduleService.ScheduleServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:8071");
});

builder.Services.AddGrpcClient<PlayersGrpcService.PlayersGrpcServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:8071");
});

builder.Services.AddGrpcClient<UserGrpcService.UserGrpcServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:5000");
});

builder.Services.AddGrpcClient<CharacterService.CharacterServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:5000");
});

builder.Services.AddGrpcClient<GameStatusService.GameStatusServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:8069");
});

builder.Services.AddGrpcClient<CharacterStatusService.CharacterStatusServiceClient>((_, o) =>
{
    o.Address = new Uri("http://localhost:8069");
});

// builder.Services.AddPresentationKafka(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

/*builder.Services.AddPlatformBackgroundTasks(configurator => configurator
    .UsePostgresPersistence(postgres => postgres.BindConfiguration("Infrastructure:BackgroundTasks:Persistence"))
    .ConfigureScheduling(scheduling => scheduling.BindConfiguration("Infrastructure:BackgroundTasks:Scheduling"))
    .UseHangfireScheduling(hangfire => hangfire
        .ConfigureOptions(o => o.BindConfiguration("Infrastructure:BackgroundTasks:Scheduling:Hangfire"))
        .UsePostgresJobStorage())
    .ConfigureExecution(builder.Configuration.GetSection("Infrastructure:BackgroundTasks:Execution"))
    .AddApplicationBackgroundTasks());*/

builder.Services.AddPlatformEvents(b => b.AddPresentationKafkaHandlers());

builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UsePlatformObservability();

app.UsePresentationGrpc();
app.MapControllers();

await app.RunAsync();