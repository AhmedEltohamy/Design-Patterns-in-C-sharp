namespace Chain_of_Responsibility.Entities;

internal class Document
{
    public string Title { get; private set; }
    
    public DateTimeOffset LastModified { get; private set; }

    public bool ApprovedByLitigation { get; private set; }
    
    public bool ApprovedByManagement { get; private set; }

    public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByLitigation = approvedByLitigation;
        ApprovedByManagement = approvedByManagement;
    }
}
