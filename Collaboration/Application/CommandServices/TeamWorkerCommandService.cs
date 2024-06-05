using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
using agrisynth_backend.Shared.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.CommandServices;

public class TeamWorkerCommandService : ITeamWorkerCommandService
{
    private readonly ITeamWorkerRepository _teamWorkerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TeamWorkerCommandService(ITeamWorkerRepository teamWorkerRepository, IUnitOfWork unitOfWork)
    {
        _teamWorkerRepository = teamWorkerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TeamWorker?> Handle(CreateTeamWorkerCommand command)
    {
        var teamWorker = new TeamWorker(command);
        try
        {
            await _teamWorkerRepository.AddAsync(teamWorker);
            await _unitOfWork.CompleteAsync();
            return teamWorker;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the team worker: {e.Message}");
            return null;
        }
    }
}