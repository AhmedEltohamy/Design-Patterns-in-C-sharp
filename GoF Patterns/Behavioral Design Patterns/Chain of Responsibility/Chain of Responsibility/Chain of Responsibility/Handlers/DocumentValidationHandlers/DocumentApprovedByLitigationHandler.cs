using Chain_of_Responsibility.Entities;
using System.ComponentModel.DataAnnotations;

namespace Chain_of_Responsibility.Handlers.DocumentValidationHandlers;

internal class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document>? _next;

    public void Handle(Document request)
    {
        if (!request.ApprovedByLitigation)
            throw new ValidationException("Document must be approved by litigation.");

        _next?.Handle(request);
    }

    public IHandler<Document> SetNext(IHandler<Document> nextHandler)
    {
        _next = nextHandler;
        return nextHandler;
    }
}
