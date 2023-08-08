using Chain_of_Responsibility.Entities;
using Chain_of_Responsibility.Handlers.DocumentValidationHandlers;
using System.ComponentModel.DataAnnotations;

var validDocument = new Document("Design Patterns in C#", DateTimeOffset.UtcNow, true, true);

var invalidDocument = new Document("C# in Depth", DateTimeOffset.UtcNow, false, true);

var documentValidationHandlersChain = new DocumentTitleHandler();
documentValidationHandlersChain.SetNext(new DocumentLastModifiedHandler())
                               .SetNext(new DocumentApprovedByLitigationHandler())
                               .SetNext(new DocumentApprovedByManagementHandler());


try
{
    documentValidationHandlersChain.Handle(validDocument);
    documentValidationHandlersChain.Handle(invalidDocument);
}
catch(ValidationException e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(e.Message);
    Console.ForegroundColor = ConsoleColor.White;
}

Console.ReadKey();