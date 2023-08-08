using Chain_of_Responsibility.Entities;
using System.ComponentModel.DataAnnotations;

namespace Chain_of_Responsibility.Handlers.DocumentValidationHandlers;

internal class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _next;

    public void Handle(Document request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ValidationException("Title must be filled out.");

        _next?.Handle(request);
    }

    public IHandler<Document> SetNext(IHandler<Document> nextHandler)
    {
        _next = nextHandler;
        return nextHandler;
    }
}
