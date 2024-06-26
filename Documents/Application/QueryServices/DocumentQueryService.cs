using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Queries;
using agrisynth_backend.Documents.Domain.Repositories;
using agrisynth_backend.Documents.Domain.Services;

namespace agrisynth_backend.Documents.Application.QueryServices;

public class DocumentQueryService : IDocumentQueryService
{
    private readonly IDocumentRepository _documentRepository;
    
    public DocumentQueryService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }
    
    public async Task<IEnumerable<Document>> Handle(GetAllDocumentsQuery query)
    {
        return await _documentRepository.ListAsync();
    }
    
    public async Task<Document?> Handle(GetDocumentByIdQuery query)
    {
        return await _documentRepository.FindByIdAsync(query.Id);
    }
    
}