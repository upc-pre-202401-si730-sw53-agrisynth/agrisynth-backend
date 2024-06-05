using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.QueryServices;

public class TeamWorkerQueryService : ITeamWorkerQueryService
{
    private readonly ITeamWorkerRepository _teamWorkerRepository;

    public TeamWorkerQueryService(ITeamWorkerRepository teamWorkerRepository)
    {
        _teamWorkerRepository = teamWorkerRepository;
    }

    public async Task<TeamWorker?> Handle(GetTeamWorkerByIdQuery query)
    {
        return await _teamWorkerRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<TeamWorker>> Handle(GetAllTeamWorkersQuery query)
    {
        return await _teamWorkerRepository.ListAsync();
    }
}