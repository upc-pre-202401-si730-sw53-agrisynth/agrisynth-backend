using agrisynth_backend.Resource.Domain.Model.Aggregates;
using agrisynth_backend.Resource.Domain.Model.Queries;

namespace agrisynth_backend.Resource.Domain.Services;

public interface IResourceItemQueryService
{
    Task<ResourceItem?> Handle(GetResourceItemByIdQuery query);
    Task<IEnumerable<ResourceItem>> Handle(GetAllResourceItemsQuery query);
}