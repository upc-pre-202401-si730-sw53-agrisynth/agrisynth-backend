using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Services;
using agrisynth_backend.Collaboration.Domain.Repositories;
using agrisynth_backend.Shared.Domain.Repositories;
namespace agrisynth_backend.Collaboration.Application.CommandServices;

public class WorkerCommandService : IWorkerCommandService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WorkerCommandService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
    {
        _workerRepository = workerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Worker?> Handle(CreateWorkerCommand command)
    {
        var worker = new Worker(command);
        try
        {
            await _workerRepository.AddAsync(worker);
            await _unitOfWork.CompleteAsync();
            return worker;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the worker: {e.Message}");
            return null;
        }
    }

    public async Task<Worker?> Handle(UpdateWorkerCommand command)
    {
        var worker = await _workerRepository.FindByIdAsync(command.Id);
        if (worker == null) return null;

        worker.Update(command);
        try
        {
            _workerRepository.Update(worker);
            await _unitOfWork.CompleteAsync();
            return worker;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the worker: {e.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(DeleteWorkerCommand command)
    {
        var worker = await _workerRepository.FindByIdAsync(command.Id);
        if (worker == null) return false;

        try
        {
            _workerRepository.Remove(worker);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the worker: {e.Message}");
            return false;
        }
    }
}
