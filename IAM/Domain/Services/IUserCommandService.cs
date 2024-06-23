using agrisynth_backend.IAM.Domain.Model.Aggregates;
using agrisynth_backend.IAM.Domain.Model.Commands;

namespace agrisynth_backend.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}