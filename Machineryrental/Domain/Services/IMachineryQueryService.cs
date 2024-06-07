using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Model.Queries;

namespace agrisynth_backend.Machineryrental.Domain.Services;

public interface IMachineryQueryService
{
    Task<Machinery?> Handle(GetMachineryByIdQuery query);
    Task<IEnumerable<Machinery>> Handle(GetAllMachinerysQuery query);
}