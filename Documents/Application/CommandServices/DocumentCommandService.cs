using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Commands;
using agrisynth_backend.Documents.Domain.Repositories;
using agrisynth_backend.Documents.Domain.Services;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.Documents.Application.CommandServices;

public class DocumentCommandService : IDocumentCommandService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentCommandService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(CreateDocumentCommand command)
    {
        var document = new Document(command);
        try
        {
            await _documentRepository.AddAsync(document);
            await _unitOfWork.CompleteAsync();
            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the document: {e.Message}");
            return null;
        }
    }

    public async Task<Document?> Handle(UpdateDocumentCommand command)
    {
        var document = await _documentRepository.FindByIdAsync(command.Id);
        if (document == null) return null;
        document.Update(command);
        try
        {
            _documentRepository.Update(document);
            await _unitOfWork.CompleteAsync();
            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the document: {e.Message}");
            return null;
        }
    }

    public async Task<Document?> Handle(DeleteDocumentCommand command)
    {
        var document = await _documentRepository.FindByIdAsync(command.Id);
        if (document == null) return null;

        try
        {
            _documentRepository.Remove(document);
            await _unitOfWork.CompleteAsync();
            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the document: {e.Message}");
            return null;
        }
    }
}
