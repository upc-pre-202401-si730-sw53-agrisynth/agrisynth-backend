using agrisynth_backend.IAM.Domain.Model.Aggregates;
using agrisynth_backend.IAM.Interfaces.REST.Resources;

namespace agrisynth_backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    } 
}