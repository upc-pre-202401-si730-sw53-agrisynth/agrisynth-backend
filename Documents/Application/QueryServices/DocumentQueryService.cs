using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Queries;
using agrisynth_backend.Documents.Domain.Repositories;
using agrisynth_backend.Documents.Domain.Services;

namespace agrisynth_backend.Documents.Application.QueryServices;

public class DocumentQueryService(IDocumentRepository documentRepository) : IDocumentQueryService
{
    public async Task<IEnumerable<Document>> Handle(GetAllDocumentsQuery query)
    {
        return await documentRepository.ListAsync();
    }
    
    public async Task<Document?> Handle(GetDocumentByIdQuery query)
    {
        return await documentRepository.FindByIdAsync(query.DocumentId);
    }
    
}