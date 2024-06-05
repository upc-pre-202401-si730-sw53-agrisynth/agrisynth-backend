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
}