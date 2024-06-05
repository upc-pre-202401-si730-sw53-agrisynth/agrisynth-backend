using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class CreateTeamWorkerCommandFromResourceAssembler
{
    public static CreateTeamWorkerCommand ToCommandFromResource(CreateTeamWorkerResource resource)
    {
        return new CreateTeamWorkerCommand(resource.TeamId, resource.WorkerId);
    }
}