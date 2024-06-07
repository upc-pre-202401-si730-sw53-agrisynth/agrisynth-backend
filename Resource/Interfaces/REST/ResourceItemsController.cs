using System.Net.Mime;
using agrisynth_backend.Resource.Domain.Model.Queries;
using agrisynth_backend.Resource.Domain.Services;
using agrisynth_backend.Resource.Interfaces.REST.Resources;
using agrisynth_backend.Resource.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace agrisynth_backend.Resource.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ResourceItemsController(
    IResourceItemCommandService resourceItemCommandService,
    IResourceItemQueryService resourceItemQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateResourceItem([FromBody] CreateResourceItemResource resource)
    {
        var createResourceItemCommand = CreateResourceItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var resourceItem = await resourceItemCommandService.Handle(createResourceItemCommand);
        if (resourceItem is null) return BadRequest();
        var resourceItemResource = ResourceItemResourceFromEntityAssembler.ToResourceFromEntity(resourceItem);
        return CreatedAtAction(nameof(GetResourceItemById), new { id = resourceItemResource.Id }, resourceItemResource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetResourceItemById(int id)
    {
        var getResourceItemByIdQuery = new GetResourceItemByIdQuery(id);
        var resourceItem = await resourceItemQueryService.Handle(getResourceItemByIdQuery);
        if (resourceItem == null) return NotFound();
        var resourceItemResource = ResourceItemResourceFromEntityAssembler.ToResourceFromEntity(resourceItem);
        return Ok(resourceItemResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllResourceItems()
    {
        var getAllResourceItemsQuery = new GetAllResourceItemsQuery();
        var resourceItems = await resourceItemQueryService.Handle(getAllResourceItemsQuery);
        var resourceItemResources = resourceItems.Select(ResourceItemResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resourceItemResources);
    }



}