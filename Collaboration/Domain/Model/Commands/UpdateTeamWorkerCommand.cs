namespace agrisynth_backend.Collaboration.Domain.Model.Commands;

public record UpdateTeamWorkerCommand(int Id, int TeamId, int WorkerId);
