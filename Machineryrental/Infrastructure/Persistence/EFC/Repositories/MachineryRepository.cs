using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Repositories;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace agrisynth_backend.Machineryrental.Infrastructure.Persistence.EFC.Repositories;

public class MachineryRepository: BaseRepository<Machinery>, IMachineryRepository
{
    public MachineryRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public Task<Machinery?> FindMachineryByIdSync(int id)
    {
        return Context.Set<Machinery>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}