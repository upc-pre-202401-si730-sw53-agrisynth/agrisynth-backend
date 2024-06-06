using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Model.Commands;

namespace agrisynth_backend.Machineryrental.Domain.Services;

public interface IMachineryCommandService
{
    Task<Machinery?> Handle(CreateMachineryCommand command);
}