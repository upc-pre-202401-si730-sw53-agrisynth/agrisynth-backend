using agrisynth_backend.Resource.Domain.Model.Commands;
using agrisynth_backend.Resource.Interfaces.REST.Resources;

namespace agrisynth_backend.Resource.Interfaces.REST.Transform;

public class CreateResourceItemCommandFromResourceAssembler
{
    public static CreateResourceItemCommand ToCommandFromResource(CreateResourceItemResource resource)
    {
        return new CreateResourceItemCommand(
            resource.Name,
            resource.Quantity,
            resource.Type,
            resource.Purchase,
            resource.Sale,
            resource.ImageUrl
        );
    }
}
