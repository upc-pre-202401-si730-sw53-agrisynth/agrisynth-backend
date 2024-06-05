using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity)
    {
        return new WorkerResource(entity.Id, entity.Name);
    }
}