namespace agrisynth_backend.Profiles.Domain.Model.ValueObjects;

public record PhoneNumber(short AreaCode, string Number)
{
    public PhoneNumber(): this(0, string.Empty) {}
    public string FullPhoneNumber => $"+{AreaCode} {Number}";
}