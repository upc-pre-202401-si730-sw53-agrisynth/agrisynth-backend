using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Repositories;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
namespace agrisynth_backend.Collaboration.Infrastructure.Persistence.EFC.Repositories;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(AppDbContext context) : base(context)
    {
    }

}