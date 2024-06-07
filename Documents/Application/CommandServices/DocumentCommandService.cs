using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Documents.Domain.Model.Commands;
using agrisynth_backend.Documents.Domain.Repositories;
using agrisynth_backend.Documents.Domain.Services;
using agrisynth_backend.Shared.Domain.Repositories;

namespace agrisynth_backend.Documents.Application.CommandServices;

public class DocumentCommandService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork) : IDocumentCommandService
{
    public async Task<Document?> Handle(CreateDocumentCommand command)
    {
        var document = new Document(command);
        try
        {
            await documentRepository.AddAsync(document);
            await unitOfWork.CompleteAsync();
            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the document: {e.Message}");
            return null;
        }
    }
}