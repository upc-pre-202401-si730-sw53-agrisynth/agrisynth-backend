using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Repositories;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
namespace agrisynth_backend.Collaboration.Infrastructure.Persistence.EFC.Repositories;

public class TeamWorkerRepository : BaseRepository<TeamWorker>, ITeamWorkerRepository
{
    public TeamWorkerRepository(AppDbContext context) : base(context)
    {
    }

}