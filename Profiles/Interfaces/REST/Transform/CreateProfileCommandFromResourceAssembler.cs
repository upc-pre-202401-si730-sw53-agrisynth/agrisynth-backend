using agrisynth_backend.Profiles.Domain.Model.Commands;
using agrisynth_backend.Profiles.Interfaces.REST.Resources;

namespace agrisynth_backend.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.UserName, resource.Email,
            resource.AreaCode, resource.Number, resource.IdentityNumber);
    }
}