using agrisynth_backend.Landrental.Domain.Model.Commands;

namespace agrisynth_backend.Landrental.Domain.Model.Aggregates;

public class Terrain
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public string UsageClauses { get; private set; }
    public int SizeSquareMeters { get; private set; }
    public int Rent { get; private set; }
    public string ImageUrl { get; private set; }

    protected Terrain()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Location = string.Empty;
        this.UsageClauses = string.Empty;
        this.SizeSquareMeters = 0;
        this.Rent = 0;
        this.ImageUrl = string.Empty;
    }


    public Terrain(CreateTerrainCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
        this.Location = command.Location;
        this.UsageClauses = command.UsageClauses;
        this.SizeSquareMeters = command.SizeSquareMeters;
        this.Rent = command.Rent;
        this.ImageUrl = command.ImageUrl;
    }

}