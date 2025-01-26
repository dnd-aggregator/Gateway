using Gateway.Application.Contracts.Schedules;
using Gateway.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("gateway/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleGatewayService _scheduleGatewayService;

    public ScheduleController(IScheduleGatewayService scheduleGatewayService)
    {
        _scheduleGatewayService = scheduleGatewayService;
    }

    [HttpPost]
    public async Task<long> CreateSchedule(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayService.CreateSchedule(request, cancellationToken);
    }

    [HttpGet("{id:long}")]
    public async Task<ScheduleWithPlayersModel> GetSchedule(long id, CancellationToken cancellationToken)
    {
        return await _scheduleGatewayService.GetSchedule(id, cancellationToken);
    }
}