using agrisynth_backend.Documents.Domain.Model.Commands;
using agrisynth_backend.Documents.Interfaces.REST.Resources;

namespace agrisynth_backend.Documents.Interfaces.REST.Transform;

public class UpdateDocumentCommandFromResourceAssembler
{
    public static UpdateDocumentCommand ToCommandFromResource(int id,UpdateDocumentResource resource)
    {
        return new UpdateDocumentCommand(id, resource.Name);
    }
}