using agrisynth_backend.Resource.Domain.Model.Aggregates;
using agrisynth_backend.Resource.Interfaces.REST.Resources;

namespace agrisynth_backend.Resource.Interfaces.REST.Transform;

public class ResourceItemResourceFromEntityAssembler
{
    public static ResourceItemResource ToResourceFromEntity(ResourceItem entity)
    {
        return new ResourceItemResource(
            entity.Id,
            entity.Name,
            entity.Quantity,
            entity.Type,
            entity.Purchase,
            entity.Sale,
            entity.ImageUrl
            );
    }
}