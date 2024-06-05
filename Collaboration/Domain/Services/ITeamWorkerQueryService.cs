using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface ITeamWorkerQueryService
{
    Task<TeamWorker?> Handle(GetTeamWorkerByIdQuery query);
    Task<IEnumerable<TeamWorker>> Handle(GetAllTeamWorkersQuery query);
}