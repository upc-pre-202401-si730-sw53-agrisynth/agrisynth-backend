namespace agrisynth_backend.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string UserName, string Email, short AreaCode, string Number, string IdentityNumber);