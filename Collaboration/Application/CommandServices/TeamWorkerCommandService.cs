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

    public async Task<TeamWorker?> Handle(UpdateTeamWorkerCommand command)
    {
        var teamWorker = await _teamWorkerRepository.FindByIdAsync(command.Id);
        if (teamWorker == null) return null;

        teamWorker.Update(command);
        try
        {
            _teamWorkerRepository.Update(teamWorker);
            await _unitOfWork.CompleteAsync();
            return teamWorker;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the team worker: {e.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(DeleteTeamWorkerCommand command)
    {
        var teamWorker = await _teamWorkerRepository.FindByIdAsync(command.Id);
        if (teamWorker == null) return false;

        try
        {
            _teamWorkerRepository.Remove(teamWorker);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the team worker: {e.Message}");
            return false;
        }
    }
}
