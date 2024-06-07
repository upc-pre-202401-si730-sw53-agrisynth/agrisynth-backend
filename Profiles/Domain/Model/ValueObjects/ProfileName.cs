namespace agrisynth_backend.Profiles.Domain.Model.ValueObjects;

public record ProfileName(string FirstName, string LastName, string UserName)
{
    public ProfileName(): this(string.Empty, string.Empty, string.Empty) {}
    
    public string FullName => $"{FirstName} {LastName}";
    public string FullNamePlusUserName => $"{FirstName} {LastName} {UserName}";
}