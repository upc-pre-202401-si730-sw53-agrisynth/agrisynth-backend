using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
namespace agrisynth_backend.Collaboration.Domain.Model.Entities;

public class Worker
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Worker(string name)
    {
        Name = name;
    }

    public Worker(CreateWorkerCommand command)
    {
        Name = command.Name;
    }

}