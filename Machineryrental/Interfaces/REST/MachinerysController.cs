using System.Net.Mime;
using agrisynth_backend.Machineryrental.Domain.Services;
using agrisynth_backend.Machineryrental.Domain.Model.Queries;
using agrisynth_backend.Machineryrental.Interfaces.REST.Resources;
using agrisynth_backend.Machineryrental.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace agrisynth_backend.Machineryrental.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MachinerysController(
    IMachineryCommandService machineryCommandService, 
    IMachineryQueryService machineryQueryService) 
    : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateMachinery([FromBody] CreateMachineryResource resource)
    {
        var createMachineryCommand = CreateMachineryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var machinery = await machineryCommandService.Handle(createMachineryCommand);
        if (machinery is null) return BadRequest();
        var machineryResource = MachineryResourceFromEntityAssembler.ToResourceFromEntity(machinery);
        return CreatedAtAction(nameof(GetMachineryById), new { id = machineryResource.Id }, machineryResource);  // Asegúrate de usar "id" aquí
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMachineryById(int id)
    {
        var getMachineryByIdQuery = new GetMachineryByIdQuery(id);
        var machinery = await machineryQueryService.Handle(getMachineryByIdQuery);
        if (machinery == null) return NotFound();
        var machineryResource = MachineryResourceFromEntityAssembler.ToResourceFromEntity(machinery);
        return Ok(machineryResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllMachinerys()
    {
        var getAllMachinerysQuery = new GetAllMachinerysQuery();
        var machinerys = await machineryQueryService.Handle(getAllMachinerysQuery);
        var machineryResources = machinerys.Select(MachineryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(machineryResources);
    }
    
    
    
}