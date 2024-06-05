using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Interfaces.REST.Resources;

namespace agrisynth_backend.Landrental.Interfaces.REST.Transform;

public class TerrainResourceFromEntityAssembler
{
    public static TerrainResource ToResourceFromEntity(Terrain entity)
    {
        return new TerrainResource(entity.Id, entity.Name, entity.Description, entity.Location, entity.UsageClauses,
            entity.SizeSquareMeters, entity.Rent, entity.ImageUrl);
    }
}