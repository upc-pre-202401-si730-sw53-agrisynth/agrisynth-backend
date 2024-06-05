using agrisynth_backend.Landrental.Domain.Model.Commands;
using agrisynth_backend.Landrental.Interfaces.REST.Resources;

namespace agrisynth_backend.Landrental.Interfaces.REST.Transform;

public class CreateTerrainCommandFromResourceAssembler
{
    public static CreateTerrainCommand ToCommandFromResource(CreateTerrainResource resource)
    {
        return new CreateTerrainCommand(resource.Name, resource.Description, resource.Location, resource.UsageClauses,
            resource.SizeSquareMeters, resource.Rent, resource.ImageUrl);
    }
}