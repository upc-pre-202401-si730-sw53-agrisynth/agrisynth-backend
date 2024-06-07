using agrisynth_backend.Profiles.Domain.Model.Commands;
using agrisynth_backend.Profiles.Domain.Model.Queries;
using agrisynth_backend.Profiles.Domain.Model.ValueObjects;
using agrisynth_backend.Profiles.Domain.Services;

namespace agrisynth_backend.Profiles.Interfaces.ACL.Services;

/**
 * Profiles context facade.
 *
 * <summary>
 * This class represents the profiles context facade, part of the profiles anti-corruption layer.
 * It contains the methods to interact with the profiles context from other bounded context.
 * </summary>
 */
public class ProfilesContextFacade (IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    /**
     * Create profile
     * <param name="firstName">The first name of the profile</param>
     * <param name="lastName">The last name of the profile</param>
     * <param name="userName">The nickname of the profile</param>
     * <param name="address">The email of the profile</param>
     * <param name="areaCode">The area code of the phone number of the profile</param>
     * <param name="number">The phone number of the profile</param>
     * <param name="identityNumber">The DNI of the profile</param>
     * <returns>The profile id</returns>
     */
    
    public async Task<int> CreateProfile(string firstName, string lastName, string userName, string address,
        short areaCode, string number, string identityNumber)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, userName, address,
            areaCode, number, identityNumber);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
    
    /**
     * Fetch a profile id by email.
     *
     * <param name="email">The email of the profile</param>
     * <returns>The profile id</returns>
     *
     */
    
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}