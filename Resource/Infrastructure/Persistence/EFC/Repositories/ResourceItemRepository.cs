using agrisynth_backend.Resource.Domain.Model.Aggregates;
using agrisynth_backend.Resource.Domain.Repositories;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace agrisynth_backend.Resource.Infrastructure.Persistence.EFC.Repositories;

public class ResourceItemRepository : BaseRepository<ResourceItem>, IResourceItemRepository
{
    public ResourceItemRepository(AppDbContext context)
        : base(context) { }

    /*    public Task<ResourceItem?> FindResourceItemByIdSync(int id)
        {
            return Context.Set<ResourceItem>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }*/
}
