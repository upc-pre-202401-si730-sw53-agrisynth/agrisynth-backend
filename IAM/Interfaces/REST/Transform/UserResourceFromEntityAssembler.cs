using agrisynth_backend.IAM.Domain.Model.Aggregates;
using agrisynth_backend.IAM.Interfaces.REST.Resources;

namespace agrisynth_backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}