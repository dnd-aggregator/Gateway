using Gateway.Application.Contracts.Characters;
using Gateway.Application.Contracts.Players;
using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Contracts.Users;
using Gateway.Application.Models.Characters;
using Gateway.Application.Models.Players;
using Gateway.Application.Models.Schedules;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Schedules;

public class ScheduleGatewayService : IScheduleGatewayService
{
    private readonly IScheduleGatewayClient _scheduleGatewayClient;
    private readonly IPlayerGatewayClient _playerGatewayClient;
    private readonly IUserGatewayClient _userGatewayClient;
    private readonly ICharacterGatewayClient _characterGatewayClient;

    public ScheduleGatewayService(
        IScheduleGatewayClient scheduleGatewayClient,
        IPlayerGatewayClient playerGatewayClient,
        IUserGatewayClient userGatewayClient,
        ICharacterGatewayClient characterGatewayClient)
    {
        _scheduleGatewayClient = scheduleGatewayClient;
        _playerGatewayClient = playerGatewayClient;
        _userGatewayClient = userGatewayClient;
        _characterGatewayClient = characterGatewayClient;
    }

    public async Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayClient.CreateSchedule(request, cancellationToken);
    }

    public async Task<ScheduleWithPlayersModel> GetSchedule(long id, CancellationToken cancellationToken)
    {
        ScheduleGatewayModel schedule = await _scheduleGatewayClient.GetSchedule(id, cancellationToken);

        UserGatewayModel master = await _userGatewayClient.GetUser(schedule.MasterId, cancellationToken);

        IEnumerable<PlayerGatewayModel> players =
            await _playerGatewayClient.GetPlayersByScheduleId(schedule.Id, cancellationToken);

        var users = new List<UserGatewayWithCharacterModel>();
        foreach (PlayerGatewayModel player in players)
        {
            UserGatewayModel user = await _userGatewayClient.GetUser(player.UserId, cancellationToken);
            CharacterGatewayModel character =
                await _characterGatewayClient.GetCharacter(player.CharacterId, cancellationToken);
            users.Add(new UserGatewayWithCharacterModel(user, character));
        }

        return new ScheduleWithPlayersModel(
            Id: schedule.Id,
            Master: master,
            Location: schedule.Location,
            Date: schedule.Date,
            Status: schedule.Status,
            Users: users);
    }

    public async Task<IEnumerable<ScheduleWithPlayersModel>> GetSchedules(
        GetSchedulesRequest request,
        CancellationToken cancellationToken)
    {
        IEnumerable<ScheduleGatewayModel> schedulesWithoutPlayers =
            await _scheduleGatewayClient.GetSchedules(request, cancellationToken);

        var schedules = new List<ScheduleWithPlayersModel>();

        foreach (ScheduleGatewayModel schedule in schedulesWithoutPlayers)
        {
            IEnumerable<PlayerGatewayModel> players =
                await _playerGatewayClient.GetPlayersByScheduleId(schedule.Id, cancellationToken);

            var users = new List<UserGatewayWithCharacterModel>();

            foreach (PlayerGatewayModel player in players)
            {
                UserGatewayModel user = await _userGatewayClient.GetUser(player.UserId, cancellationToken);
                CharacterGatewayModel character =
                    await _characterGatewayClient.GetCharacter(player.CharacterId, cancellationToken);
                users.Add(new UserGatewayWithCharacterModel(user, character));
            }

            UserGatewayModel master = await _userGatewayClient.GetUser(schedule.MasterId, cancellationToken);

            schedules.Add(new ScheduleWithPlayersModel(
                schedule.Id,
                master,
                schedule.Location,
                schedule.Date,
                schedule.Status,
                users));
        }

        return schedules;
    }

    public async Task PatchScheduleStatus(long scheduleId, ScheduleStatus status, CancellationToken cancellationToken)
    {
        await _scheduleGatewayClient.PatchScheduleStatus(scheduleId, status, cancellationToken);
    }
}