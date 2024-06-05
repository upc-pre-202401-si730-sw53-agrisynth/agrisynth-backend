namespace agrisynth_backend.Landrental.Interfaces.REST.Resources;

public record CreateTerrainResource(string Name, string Description, string Location, string UsageClauses, int SizeSquareMeters, int Rent, string ImageUrl);