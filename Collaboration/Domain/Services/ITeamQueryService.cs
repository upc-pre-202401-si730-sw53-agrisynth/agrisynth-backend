using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Model.Entities;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface ITeamQueryService
{
    Task<Team?> Handle(GetTeamByIdQuery query);
    Task<IEnumerable<Team>> Handle(GetAllTeamsQuery query);
}