using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;

namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform
{
    public static class UpdateWorkerCommandFromResourceAssembler
    {
        public static UpdateWorkerCommand ToCommandFromResource(int id, UpdateWorkerResource resource)
        {
            return new UpdateWorkerCommand(id, resource.Name);
        }
    }
}