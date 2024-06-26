using agrisynth_backend.Documents.Domain.Model.Commands;
namespace agrisynth_backend.Documents.Domain.Model.Aggregates;

public class Document
{
    public int Id { get; }
    public string Name { get; private set; }

    protected Document()
    {
        this.Name = string.Empty;
    }

    public Document(CreateDocumentCommand command)
    {
        this.Name = command.Name;
    }
    public Document(UpdateDocumentCommand command)
    {
        this.Name = command.Name;
    }
    public void Update(UpdateDocumentCommand command)
    {
        this.Name = command.Name;
    }
}