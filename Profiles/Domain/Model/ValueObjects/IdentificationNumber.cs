namespace agrisynth_backend.Profiles.Domain.Model.ValueObjects;

public record IdentificationNumber(string IdentityNumber)
{
    public IdentificationNumber(): this(string.Empty) {}
}