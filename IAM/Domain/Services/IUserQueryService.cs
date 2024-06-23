using agrisynth_backend.IAM.Domain.Model.Aggregates;
using agrisynth_backend.IAM.Domain.Model.Queries;

namespace agrisynth_backend.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}