using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class CreateTeamCommandFromResourceAssembler
{
    public static CreateTeamCommand ToCommandFromResource(CreateTeamResource resource)
    {
        return new CreateTeamCommand(resource.Name);
    }
}