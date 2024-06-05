using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Model.Entities;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface ITeamCommandService
{
    Task<Team?> Handle(CreateTeamCommand command);
}