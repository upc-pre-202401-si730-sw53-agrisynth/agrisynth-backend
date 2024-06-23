namespace agrisynth_backend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, string Token);