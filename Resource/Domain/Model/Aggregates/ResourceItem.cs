using agrisynth_backend.Resource.Domain.Model.Commands;

namespace agrisynth_backend.Resource.Domain.Model.Aggregates;

public class ResourceItem
{
    public int Id { get; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public string Type { get; private set; }
    public string Purchase { get; private set; }
    public string Sale { get; private set; }
    public string ImageUrl { get; private set; }

    protected ResourceItem()
    {
        this.Name = string.Empty;
        this.Quantity = 0;
        this.Type = string.Empty;
        this.Purchase = string.Empty;
        this.Sale = string.Empty;
        this.ImageUrl = string.Empty;
    }

    public ResourceItem(CreateResourceItemCommand command)
    {
        this.Name = command.Name;
        this.Quantity = command.Quantity;
        this.Type = command.Type;
        this.Purchase = command.Purchase;
        this.Sale = command.Sale;
        this.ImageUrl = command.ImageUrl;
    }
}