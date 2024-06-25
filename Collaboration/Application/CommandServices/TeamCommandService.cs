using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
using agrisynth_backend.Shared.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.CommandServices;

public class TeamCommandService : ITeamCommandService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TeamCommandService(ITeamRepository teamRepository, IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Team?> Handle(CreateTeamCommand command)
    {
        var team = new Team(command);
        try
        {
            await _teamRepository.AddAsync(team);
            await _unitOfWork.CompleteAsync();
            return team;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the team: {e.Message}");
            return null;
        }
    }

    public async Task<Team?> Handle(UpdateTeamCommand command)
    {
        var team = await _teamRepository.FindByIdAsync(command.Id);
        if (team == null) return null;

        team.Update(command);
        try
        {
            _teamRepository.Update(team);
            await _unitOfWork.CompleteAsync();
            return team;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the team: {e.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(DeleteTeamCommand command)
    {
        var team = await _teamRepository.FindByIdAsync(command.Id);
        if (team == null) return false;

        try
        {
            _teamRepository.Remove(team);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the team: {e.Message}");
            return false;
        }
    }
}


