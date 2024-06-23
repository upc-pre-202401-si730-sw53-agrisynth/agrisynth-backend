using agrisynth_backend.IAM.Domain.Model.Aggregates;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}