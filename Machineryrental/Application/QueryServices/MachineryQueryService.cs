using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Model.Queries;
using agrisynth_backend.Machineryrental.Domain.Repositories;
using agrisynth_backend.Machineryrental.Domain.Services;

namespace agrisynth_backend.Machineryrental.Application.QueryServices;

public class MachineryQueryService(IMachineryRepository machineryRepository) : IMachineryQueryService
{
    public async Task<IEnumerable<Machinery>> Handle(GetAllMachinerysQuery query)
    {
        return await machineryRepository.ListAsync();
    }
    
    public async Task<Machinery?> Handle(GetMachineryByIdQuery query)
    {
        return await machineryRepository.FindByIdAsync(query.MachineryId);
    }
    
}