namespace agrisynth_backend.Resource.Domain.Model.Commands;

public record UpdateResourceItemCommand(
    int Id,
    string Name,
    int Quantity,
    string Type, 
    string Purchase,
    string Sale,
    string ImageUrl
    );