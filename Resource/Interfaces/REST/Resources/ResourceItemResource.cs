namespace agrisynth_backend.Resource.Interfaces.REST.Resources;

public record ResourceItemResource(
    int Id,
    string Name,
    int Quantity,
    string Type,
    string Purchase,
    string Sale,
    string ImageUrl
);
