namespace agrisynth_backend.Resource.Domain.Model.Commands;

public record CreateResourceItemCommand(
    string Name,
    int Quantity,
    string Type,
    string Purchase,
    string Sale,
    string ImageUrl
);
