using Chain_of_Responsibility.Entities;
using System.ComponentModel.DataAnnotations;

namespace Chain_of_Responsibility.Handlers.DocumentValidationHandlers;

internal class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _next;

    public void Handle(Document request)
    {
        if (!request.ApprovedByManagement)
            throw new ValidationException("Document must be approved by management.");

        _next?.Handle(request);
    }

    public IHandler<Document> SetNext(IHandler<Document> nextHandler)
    {
        _next = nextHandler;
        return nextHandler;
    }
}
