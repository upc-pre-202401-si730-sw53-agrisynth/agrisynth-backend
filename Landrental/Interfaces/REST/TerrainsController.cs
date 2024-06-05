using System.Net.Mime;
using agrisynth_backend.Landrental.Domain.Model.Queries;
using agrisynth_backend.Landrental.Domain.Services;
using agrisynth_backend.Landrental.Interfaces.REST.Resources;
using agrisynth_backend.Landrental.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace agrisynth_backend.Landrental.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TerrainsController(
    ITerrainCommandService terrainCommandService, 
    ITerrainQueryService terrainQueryService) 
    : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateTerrain([FromBody] CreateTerrainResource resource)
    {
        var createTerrainCommand = CreateTerrainCommandFromResourceAssembler.ToCommandFromResource(resource);
        var terrain = await terrainCommandService.Handle(createTerrainCommand);
        if (terrain is null) return BadRequest();
        var terrainResource = TerrainResourceFromEntityAssembler.ToResourceFromEntity(terrain);
        return CreatedAtAction(nameof(GetTerrainById), new { id = terrainResource.Id }, terrainResource);  // Asegúrate de usar "id" aquí
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTerrainById(int id)
    {
        var getTerrainByIdQuery = new GetTerrainByIdQuery(id);
        var terrain = await terrainQueryService.Handle(getTerrainByIdQuery);
        if (terrain == null) return NotFound();
        var terrainResource = TerrainResourceFromEntityAssembler.ToResourceFromEntity(terrain);
        return Ok(terrainResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTerrains()
    {
        var getAllTerrainsQuery = new GetAllTerrainsQuery();
        var terrains = await terrainQueryService.Handle(getAllTerrainsQuery);
        var terrainResources = terrains.Select(TerrainResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(terrainResources);
    }
    
    
    
}