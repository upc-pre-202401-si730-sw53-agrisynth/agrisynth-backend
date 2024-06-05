using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class TeamWorkerResourceFromEntityAssembler
{
    public static TeamWorkerResource ToResourceFromEntity(TeamWorker entity)
    {
        return new TeamWorkerResource(entity.Id, entity.TeamId, entity.WorkerId);
    }
}