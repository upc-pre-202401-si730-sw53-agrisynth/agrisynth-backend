using agrisynth_backend.Shared.Domain.Repositories;
using agrisynth_backend.Profiles.Domain.Model.Aggregates;
using agrisynth_backend.Profiles.Domain.Model.Commands;
using agrisynth_backend.Profiles.Domain.Repositories;
using agrisynth_backend.Profiles.Domain.Services;

namespace agrisynth_backend.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}