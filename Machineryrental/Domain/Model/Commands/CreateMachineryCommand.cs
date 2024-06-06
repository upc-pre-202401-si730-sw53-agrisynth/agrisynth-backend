namespace agrisynth_backend.Machineryrental.Domain.Model.Commands;

public record CreateMachineryCommand(string Name, int Price, string ImageUrl);
//change reponsability: agentes y cada uno realiza una parte de la tarea
// patron gof