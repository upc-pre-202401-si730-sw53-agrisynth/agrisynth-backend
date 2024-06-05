using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class CreateWorkerCommandFromResourceAssembler
{
    public static CreateWorkerCommand ToCommandFromResource(CreateWorkerResource resource)
    {
        return new CreateWorkerCommand(resource.Name);
    }
}