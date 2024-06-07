using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Interfaces.REST.Resources;

namespace agrisynth_backend.Documents.Interfaces.REST.Transform;

public class DocumentResourceFromEntityAssembler
{
    public static DocumentResource ToResourceFromEntity(Document entity)
    {
        return new DocumentResource(entity.Id, entity.Name);
    }
}