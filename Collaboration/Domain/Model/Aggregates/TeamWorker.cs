using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
namespace agrisynth_backend.Collaboration.Domain.Model.Aggregates;


public partial class TeamWorker
{
    public int Id { get; private set; }
    public int TeamId { get; private set; }
    public int WorkerId { get; private set; }
    public Team Team { get; private set; }
    public Worker Worker { get; private set; }

    public TeamWorker(int teamId, int workerId)
    {
        TeamId = teamId;
        WorkerId = workerId;
    }

    public TeamWorker(CreateTeamWorkerCommand command)
    {
        TeamId = command.TeamId;
        WorkerId = command.WorkerId;
    }
}