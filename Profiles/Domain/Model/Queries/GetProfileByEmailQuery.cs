using agrisynth_backend.Profiles.Domain.Model.ValueObjects;

namespace agrisynth_backend.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);