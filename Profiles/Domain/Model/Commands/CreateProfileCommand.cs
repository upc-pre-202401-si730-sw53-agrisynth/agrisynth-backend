namespace agrisynth_backend.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string UserName, string Address, short AreaCode, string Number, string IdentityNumber);