using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
using agrisynth_backend.Collaboration.Interfaces.REST.Transform;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
namespace agrisynth_backend.Collaboration.Interfaces
{
[ApiController]
[Route("api/v1/[controller]")]
public class TeamWorkersController : ControllerBase
{
    private readonly ITeamWorkerCommandService _teamWorkerCommandService;
    private readonly ITeamWorkerQueryService _teamWorkerQueryService;

    public TeamWorkersController(ITeamWorkerCommandService teamWorkerCommandService, ITeamWorkerQueryService teamWorkerQueryService)
    {
        _teamWorkerCommandService = teamWorkerCommandService;
        _teamWorkerQueryService = teamWorkerQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeamWorker(CreateTeamWorkerResource resource)
    {
        var createTeamWorkerCommand = CreateTeamWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var teamWorker = await _teamWorkerCommandService.Handle(createTeamWorkerCommand);
        if (teamWorker is null) return BadRequest();
        var teamWorkerResource = TeamWorkerResourceFromEntityAssembler.ToResourceFromEntity(teamWorker);
        return CreatedAtAction(nameof(GetTeamWorkerById), new { teamWorkerId = teamWorkerResource.Id }, teamWorkerResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeamWorkers()
    {
        var getAllTeamWorkersQuery = new GetAllTeamWorkersQuery();
        var teamWorkers = await _teamWorkerQueryService.Handle(getAllTeamWorkersQuery);
        var teamWorkerResources = teamWorkers.Select(TeamWorkerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(teamWorkerResources);
    }

    [HttpGet("{teamWorkerId:int}")]
    public async Task<IActionResult> GetTeamWorkerById(int teamWorkerId)
    {
        var getTeamWorkerByIdQuery = new GetTeamWorkerByIdQuery(teamWorkerId);
        var teamWorker = await _teamWorkerQueryService.Handle(getTeamWorkerByIdQuery);
        if (teamWorker == null) return NotFound();
        var teamWorkerResource = TeamWorkerResourceFromEntityAssembler.ToResourceFromEntity(teamWorker);
        return Ok(teamWorkerResource);
    }

    [HttpPut("{teamWorkerId:int}")]
    public async Task<IActionResult> UpdateTeamWorker(int teamWorkerId, UpdateTeamWorkerResource resource)
    {
        var updateTeamWorkerCommand = UpdateTeamWorkerCommandFromResourceAssembler.ToCommandFromResource(teamWorkerId, resource);
        var teamWorker = await _teamWorkerCommandService.Handle(updateTeamWorkerCommand);
        if (teamWorker == null) return NotFound();
        var teamWorkerResource = TeamWorkerResourceFromEntityAssembler.ToResourceFromEntity(teamWorker);
        return Ok(teamWorkerResource);
    }

    [HttpDelete("{teamWorkerId:int}")]
    public async Task<IActionResult> DeleteTeamWorker(int teamWorkerId)
    {
        var deleteTeamWorkerCommand = new DeleteTeamWorkerCommand(teamWorkerId);
        var result = await _teamWorkerCommandService.Handle(deleteTeamWorkerCommand);
        if (!result) return NotFound();
        return NoContent();
    }
}


}