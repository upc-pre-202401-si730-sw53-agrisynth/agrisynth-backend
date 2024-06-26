using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;

namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform
{
    public static class UpdateTeamCommandFromResourceAssembler
    {
        public static UpdateTeamCommand ToCommandFromResource(int id, UpdateTeamResource resource)
        {
            return new UpdateTeamCommand(id, resource.Name);
        }
    }
}