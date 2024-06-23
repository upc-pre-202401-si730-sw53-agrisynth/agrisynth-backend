using agrisynth_backend.IAM.Domain.Model.Aggregates;

namespace agrisynth_backend.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}