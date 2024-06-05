using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Model.Entities;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface IWorkerQueryService
{
    Task<Worker?> Handle(GetWorkerByIdQuery query);
    Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery query);
}