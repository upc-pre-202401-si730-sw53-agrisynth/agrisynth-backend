using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;

namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform
{
    public static class UpdateTeamWorkerCommandFromResourceAssembler
    {
        public static UpdateTeamWorkerCommand ToCommandFromResource(int id, UpdateTeamWorkerResource resource)
        {
            return new UpdateTeamWorkerCommand(id, resource.TeamId, resource.WorkerId);
        }
    }
}