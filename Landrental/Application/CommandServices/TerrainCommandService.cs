using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Landrental.Domain.Model.Commands;
using agrisynth_backend.Landrental.Domain.Repositories;
using agrisynth_backend.Landrental.Domain.Services;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.Landrental.Application.CommandServices;

public class TerrainCommandService(ITerrainRepository terrainRepository, IUnitOfWork unitOfWork) : ITerrainCommandService
{
    public async Task<Terrain?> Handle(CreateTerrainCommand command)
    {
        var terrain = new Terrain(command);
        try
        {
            await terrainRepository.AddAsync(terrain);
            await unitOfWork.CompleteAsync();
            return terrain;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the terrain: {e.Message}");
            return null;
        }
    }
}