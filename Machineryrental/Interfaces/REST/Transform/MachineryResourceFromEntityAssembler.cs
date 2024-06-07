using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Interfaces.REST.Resources;

namespace agrisynth_backend.Machineryrental.Interfaces.REST.Transform;

public class MachineryResourceFromEntityAssembler
{
    public static MachineryResource ToResourceFromEntity(Machinery entity)
    {
        return new MachineryResource(entity.Id, entity.Name, entity.Price, entity.ImageUrl);
    }
}