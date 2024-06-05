using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Domain.Model.Commands;

namespace agrisynth_backend.Landrental.Domain.Services;

public interface ITerrainCommandService
{
    Task<Terrain?> Handle(CreateTerrainCommand command);
}