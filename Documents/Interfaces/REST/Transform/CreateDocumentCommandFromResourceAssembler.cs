using agrisynth_backend.Documents.Domain.Model.Commands;
using agrisynth_backend.Documents.Interfaces.REST.Resources;

namespace agrisynth_backend.Documents.Interfaces.REST.Transform;

public class CreateDocumentCommandFromResourceAssembler
{
    public static CreateDocumentCommand ToCommandFromResource(CreateDocumentResource resource)
    {
        return new CreateDocumentCommand(resource.Name);
    }
}