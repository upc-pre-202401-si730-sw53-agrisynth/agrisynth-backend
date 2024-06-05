using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Domain.Model.Queries;
using agrisynth_backend.Landrental.Domain.Repositories;
using agrisynth_backend.Landrental.Domain.Services;

namespace agrisynth_backend.Landrental.Application.QueryServices;

public class TerrainQueryService(ITerrainRepository terrainRepository) : ITerrainQueryService
{
    public async Task<IEnumerable<Terrain>> Handle(GetAllTerrainsQuery query)
    {
        return await terrainRepository.ListAsync();
    }
    
    public async Task<Terrain?> Handle(GetTerrainByIdQuery query)
    {
        return await terrainRepository.FindByIdAsync(query.TerrainId);
    }
    
}