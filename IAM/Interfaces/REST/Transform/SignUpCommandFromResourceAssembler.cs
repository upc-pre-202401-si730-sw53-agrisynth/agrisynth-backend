using agrisynth_backend.IAM.Domain.Model.Commands;
using agrisynth_backend.IAM.Interfaces.REST.Resources;

namespace agrisynth_backend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}