namespace agrisynth_backend.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string userName, string address, 
        short areaCode, string number, string identityNumber);
    
    Task<int> FetchProfileIdByEmail(string email);
}