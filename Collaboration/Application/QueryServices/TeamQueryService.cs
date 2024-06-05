using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.QueryServices;

public class TeamQueryService : ITeamQueryService
{
    private readonly ITeamRepository _teamRepository;

    public TeamQueryService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team?> Handle(GetTeamByIdQuery query)
    {
        return await _teamRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Team>> Handle(GetAllTeamsQuery query)
    {
        return await _teamRepository.ListAsync();
    }
}
