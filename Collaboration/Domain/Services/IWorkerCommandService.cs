using agrisynth_backend.Collaboration.Domain.Model.Commands;
using agrisynth_backend.Collaboration.Domain.Model.Entities;
namespace agrisynth_backend.Collaboration.Domain.Services;

public interface IWorkerCommandService
{
    Task<Worker?> Handle(CreateWorkerCommand command);
    Task<Worker?> Handle(UpdateWorkerCommand command);
    Task<bool> Handle(DeleteWorkerCommand command);
}