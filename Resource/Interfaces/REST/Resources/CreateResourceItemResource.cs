namespace agrisynth_backend.Resource.Interfaces.REST.Resources;

public record CreateResourceItemResource(
    string Name,
    int Quantity,
    string Type,
    string Purchase,
    string Sale,
    string ImageUrl
);
