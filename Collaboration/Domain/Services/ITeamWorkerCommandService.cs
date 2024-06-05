using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface ITeamWorkerCommandService
{
    Task<TeamWorker?> Handle(CreateTeamWorkerCommand command);
}