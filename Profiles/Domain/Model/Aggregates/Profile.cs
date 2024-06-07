using agrisynth_backend.Profiles.Domain.Model.Commands;
using agrisynth_backend.Profiles.Domain.Model.ValueObjects;

namespace agrisynth_backend.Profiles.Domain.Model.Aggregates;

public partial class Profile
{

    public Profile()
    {
        Name = new ProfileName();
        Email = new EmailAddress();
        Phone = new PhoneNumber();
        IdNumber = new IdentificationNumber();
    }
    
    public Profile(string firstName, string lastName, string userName, string address, 
        short areaCode, string number, string identityNumber)
    {
        Name = new ProfileName(firstName, lastName, userName);
        Email = new EmailAddress(address);
        Phone = new PhoneNumber(areaCode, number);
        IdNumber = new IdentificationNumber(identityNumber);
    }
    
    public Profile(CreateProfileCommand command)
    {
        Name = new ProfileName(command.FirstName, command.LastName, command.UserName);
        Email = new EmailAddress(command.Address);
        Phone = new PhoneNumber(command.AreaCode, command.Number);
        IdNumber = new IdentificationNumber(command.IdentityNumber);
    }
    
    public int Id { get;}
    public ProfileName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public IdentificationNumber IdNumber { get; private set; }
    
    public string FullName => Name.FullNamePlusUserName;

    public string EmailAddress => Email.Address;

    public string FullPhoneNumber => Phone.FullPhoneNumber;

    public string IdentificationNumber => IdNumber.IdentityNumber;
}