using agrisynth_backend.Machineryrental.Domain.Model.Commands;
using agrisynth_backend.Machineryrental.Interfaces.REST.Resources;
namespace agrisynth_backend.Machineryrental.Interfaces.REST.Transform;

public class CreateMachineryCommandFromResourceAssembler
{
    public static CreateMachineryCommand ToCommandFromResource(CreateMachineryResource resource)
    {
        return new CreateMachineryCommand(resource.Name, resource.Price, resource.ImageUrl);
    }
}