using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
using agrisynth_backend.Collaboration.Interfaces.REST.Transform;

namespace agrisynth_backend.Collaboration.Interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamCommandService _teamCommandService;
        private readonly ITeamQueryService _teamQueryService;

        public TeamsController(ITeamCommandService teamCommandService, ITeamQueryService teamQueryService)
        {
            _teamCommandService = teamCommandService;
            _teamQueryService = teamQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamResource resource)
        {
            var createTeamCommand = CreateTeamCommandFromResourceAssembler.ToCommandFromResource(resource);
            var team = await _teamCommandService.Handle(createTeamCommand);
            if (team is null) return BadRequest();
            var teamResource = TeamResourceFromEntityAssembler.ToResourceFromEntity(team);
            return CreatedAtAction(nameof(GetTeamById), new { teamId = teamResource.Id }, teamResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var getAllTeamsQuery = new GetAllTeamsQuery();
            var teams = await _teamQueryService.Handle(getAllTeamsQuery);
            var teamResources = teams.Select(TeamResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(teamResources);
        }

        [HttpGet("{teamId:int}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            var getTeamByIdQuery = new GetTeamByIdQuery(teamId);
            var team = await _teamQueryService.Handle(getTeamByIdQuery);
            if (team == null) return NotFound();
            var teamResource = TeamResourceFromEntityAssembler.ToResourceFromEntity(team);
            return Ok(teamResource);
        }
    }
}