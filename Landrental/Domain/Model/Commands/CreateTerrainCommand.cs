namespace agrisynth_backend.Landrental.Domain.Model.Commands;

public record CreateTerrainCommand(string Name, string Description, string Location, string UsageClauses, int SizeSquareMeters, int Rent, string ImageUrl);