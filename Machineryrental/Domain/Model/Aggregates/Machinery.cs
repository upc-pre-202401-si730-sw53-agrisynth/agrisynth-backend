using agrisynth_backend.Machineryrental.Domain.Model.Commands;

namespace agrisynth_backend.Machineryrental.Domain.Model.Aggregates;

public class Machinery
{
    public int Id { get; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string ImageUrl { get; private set; }

    protected Machinery()
    {
        this.Name = string.Empty;
        this.Price = 0;
        this.ImageUrl = string.Empty;
    }


    public Machinery(CreateMachineryCommand command)
    {
        this.Name = command.Name;
        this.Price = command.Price;
        this.ImageUrl = command.ImageUrl;
    }

}