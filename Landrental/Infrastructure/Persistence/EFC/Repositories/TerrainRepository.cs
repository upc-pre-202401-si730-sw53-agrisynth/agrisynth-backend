using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Domain.Repositories;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace agrisynth_backend.Landrental.Infrastructure.Persistence.EFC.Repositories;

public class TerrainRepository: BaseRepository<Terrain>, ITerrainRepository
{
    public TerrainRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public Task<Terrain?> FindTerrainByIdSync(int id)
    {
        return Context.Set<Terrain>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}