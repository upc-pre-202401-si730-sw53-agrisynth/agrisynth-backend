using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Commands;

namespace agrisynth_backend.Documents.Domain.Services;

public interface IDocumentCommandService
{
    Task<Document?> Handle(CreateDocumentCommand command);

}