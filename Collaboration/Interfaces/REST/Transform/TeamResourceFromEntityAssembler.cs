using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Interfaces.REST.Resources;
namespace agrisynth_backend.Collaboration.Interfaces.REST.Transform;

public static class TeamResourceFromEntityAssembler
{
    public static TeamResource ToResourceFromEntity(Team entity)
    {
        return new TeamResource(entity.Id, entity.Name);
    }
}