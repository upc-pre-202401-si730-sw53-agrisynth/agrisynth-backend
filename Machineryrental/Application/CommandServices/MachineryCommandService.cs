using agrisynth_backend.Landrental.Domain.Services;
using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Model.Commands;
using agrisynth_backend.Machineryrental.Domain.Repositories;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.Machineryrental.Application.CommandServices;

public class MachineryCommandService(IMachineryRepository machineryRepository, IUnitOfWork unitOfWork) : IMachineryCommandService
{
    public async Task<Machinery?> Handle(CreateMachineryCommand command)
    {
        var machinery = new Machinery(command);
        try
        {
            await machineryRepository.AddAsync(machinery);
            await unitOfWork.CompleteAsync();
            return machinery;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the machinery: {e.Message}");
            return null;
        }
    }
}