using Chain_of_Responsibility.Entities;
using System.ComponentModel.DataAnnotations;

namespace Chain_of_Responsibility.Handlers.DocumentValidationHandlers;

internal class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document>? _next;

    public void Handle(Document request)
    {
        if (request.LastModified < DateTime.UtcNow.AddDays(-30))
            throw new ValidationException("Document must be modified in the last 20 days.");

        _next?.Handle(request);
    }

    public IHandler<Document> SetNext(IHandler<Document> nextHandler)
    {
        _next = nextHandler;
        return nextHandler;
    }
}
