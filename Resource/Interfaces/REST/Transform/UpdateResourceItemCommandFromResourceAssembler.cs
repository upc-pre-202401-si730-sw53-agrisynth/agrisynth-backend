using agrisynth_backend.Resource.Domain.Model.Commands;
using agrisynth_backend.Resource.Interfaces.REST.Resources;

namespace agrisynth_backend.Resource.Interfaces.REST.Transform;

public class UpdateResourceItemCommandFromResourceAssembler
{
    public static UpdateResourceItemCommand ToCommandFromResource(
        int id,
        UpdateResourceItemResource resource
    )
    {
        return new UpdateResourceItemCommand(
            id, 
            resource.Name, 
            resource.Quantity, 
            resource.Type, 
            resource.Purchase,
            resource.Sale, 
            resource.ImageUrl
            );
    }
}