using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Queries;

namespace agrisynth_backend.Documents.Domain.Services;

public interface IDocumentQueryService
{
    Task<Document?> Handle(GetDocumentByIdQuery query);
    Task<IEnumerable<Document>> Handle(GetAllDocumentsQuery query);
}