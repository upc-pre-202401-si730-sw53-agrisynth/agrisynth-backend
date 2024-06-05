using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
namespace agrisynth_backend.Collaboration.Domain.Model.Entities;

public class Team
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Team(string name)
    {
        Name = name;
    }

    public Team(CreateTeamCommand command)
    {
        Name = command.Name;
    }

}