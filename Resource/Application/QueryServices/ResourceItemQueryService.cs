using agrisynth_backend.Resource.Domain.Model.Aggregates;
using agrisynth_backend.Resource.Domain.Model.Queries;
using agrisynth_backend.Resource.Domain.Repositories;
using agrisynth_backend.Resource.Domain.Services;

namespace agrisynth_backend.Resource.Application.QueryServices;

public class ResourceItemQueryService(IResourceItemRepository resourceItemRepository) : IResourceItemQueryService
{
    public async Task<IEnumerable<ResourceItem>> Handle(GetAllResourceItemsQuery query)
    {
        return await resourceItemRepository.ListAsync();
    }

    public async Task<ResourceItem?> Handle(GetResourceItemByIdQuery query)
    {
        return await resourceItemRepository.FindByIdAsync(query.Id);
    }
}