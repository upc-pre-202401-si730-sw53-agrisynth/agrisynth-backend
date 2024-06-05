namespace agrisynth_backend.Landrental.Interfaces.REST.Resources;

public record TerrainResource(int Id, string Name, string Description, string Location, string UsageClauses, int SizeSquareMeters, int Rent, string ImageUrl);