using System.Net.Mime;
using agrisynth_backend.Documents.Domain.Model.Commands;
using agrisynth_backend.Documents.Domain.Model.Queries;
using agrisynth_backend.Documents.Domain.Services;
using agrisynth_backend.Documents.Interfaces.REST.Resources;
using agrisynth_backend.Documents.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace agrisynth_backend.Documents.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsController(
    IDocumentCommandService documentCommandService, 
    IDocumentQueryService documentQueryService) 
    : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateDocument([FromBody] CreateDocumentResource resource)
    {
        var createDocumentCommand = CreateDocumentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var document = await documentCommandService.Handle(createDocumentCommand);
        if (document is null) return BadRequest();
        var documentResource = DocumentResourceFromEntityAssembler.ToResourceFromEntity(document);
        return CreatedAtAction(nameof(GetDocumentById), new { id = documentResource.Id }, documentResource);  // Asegúrate de usar "id" aquí
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDocumentById(int id)
    {
        var getDocumentByIdQuery = new GetDocumentByIdQuery(id);
        var document = await documentQueryService.Handle(getDocumentByIdQuery);
        if (document == null) return NotFound();
        var documentResource = DocumentResourceFromEntityAssembler.ToResourceFromEntity(document);
        return Ok(documentResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDocuments()
    {
        var getAllDocumentsQuery = new GetAllDocumentsQuery();
        var documents = await documentQueryService.Handle(getAllDocumentsQuery);
        var documentResources = documents.Select(DocumentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(documentResources);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var deleteDocumentCommand = new DeleteDocumentCommand(id);
        var document = await documentCommandService.Handle(deleteDocumentCommand);
        if (document == null) return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDocument(int id, [FromBody] UpdateDocumentResource resource)
    {
        var updateDocumentCommand = UpdateDocumentCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var document = await documentCommandService.Handle(updateDocumentCommand);
        if (document == null) return NotFound();
        var documentResource = DocumentResourceFromEntityAssembler.ToResourceFromEntity(document);
        return Ok(documentResource);
    }
}