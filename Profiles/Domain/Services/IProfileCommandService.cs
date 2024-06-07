using agrisynth_backend.Profiles.Domain.Model.Aggregates;
using agrisynth_backend.Profiles.Domain.Model.Commands;

namespace agrisynth_backend.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}