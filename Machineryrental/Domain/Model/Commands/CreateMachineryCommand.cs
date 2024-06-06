namespace agrisynth_backend.Machineryrental.Domain.Model.Commands;

public record CreateMachineryCommand(string Name, int Price, string ImageUrl);