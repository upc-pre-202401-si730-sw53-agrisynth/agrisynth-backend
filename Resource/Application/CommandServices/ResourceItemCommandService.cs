using agrisynth_backend.Resource.Domain.Model.Aggregates;
using agrisynth_backend.Resource.Domain.Model.Commands;
using agrisynth_backend.Resource.Domain.Repositories;
using agrisynth_backend.Resource.Domain.Services;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.Resource.Application.CommandServices;

public class ResourceItemCommandService(IResourceItemRepository resourceItemRepository, IUnitOfWork unitOfWork) : IResourceItemCommandService
{
    public async Task<ResourceItem?> Handle(CreateResourceItemCommand command)
    {
        var resourceItem = new ResourceItem(command);
        try
        {
            await resourceItemRepository.AddAsync(resourceItem);
            await unitOfWork.CompleteAsync();
            return resourceItem;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the resource: {e.Message}");
            return null;
        }
    }

    public async Task<ResourceItem?> Handle(UpdateResourceItemCommand command)
    {
        var resourceItem = await resourceItemRepository.FindByIdAsync(command.Id);
        if (resourceItem== null) return null;
        resourceItem.Update(command);
        try
        {
            resourceItemRepository.Update(resourceItem);
            await unitOfWork.CompleteAsync();
            return resourceItem;
        }
        catch (Exception e)
        {
          Console.WriteLine($"An error occurred while updating the resource: {e.Message}");  
            return null;
        }
    }
    
    public async Task<ResourceItem?> Handle(DeleteResourceItemCommand command)
    {
        var resourceItem = await resourceItemRepository.FindByIdAsync(command.Id);
        if (resourceItem == null) return null;

        try
        {
            resourceItemRepository.Remove(resourceItem);
            await unitOfWork.CompleteAsync();
            return resourceItem;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the resourceItem: {e.Message}");
            return null;
        }
    }
}