using Character.Validation;
using CharactersGrpc.Proto;
using Gateway.Application.Extensions;
using Gateway.Presentation.Grpc.Extensions;
using Gateway.Presentation.Http.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Schedules.Contracts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();

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

builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UsePresentationGrpc();
app.MapControllers();

await app.RunAsync();