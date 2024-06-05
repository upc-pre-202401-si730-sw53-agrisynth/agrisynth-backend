using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Model.Queries;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.QueryServices;

public class WorkerQueryService : IWorkerQueryService
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerQueryService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<Worker?> Handle(GetWorkerByIdQuery query)
    {
        return await _workerRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery query)
    {
        return await _workerRepository.ListAsync();
    }
}