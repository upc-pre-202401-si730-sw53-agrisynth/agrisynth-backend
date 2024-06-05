using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Domain.Model.Queries;

namespace agrisynth_backend.Landrental.Domain.Services;

public interface ITerrainQueryService
{
    Task<Terrain?> Handle(GetTerrainByIdQuery query);
    Task<IEnumerable<Terrain>> Handle(GetAllTerrainsQuery query);
}