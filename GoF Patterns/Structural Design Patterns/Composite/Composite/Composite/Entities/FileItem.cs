namespace Composite.Entities;

internal class FileItem : FileSystemItem
{
    public int FileMB { get; }

    public FileItem(string name, int fileMB) : base(name) => FileMB = fileMB;

    public override int GetSizeInMB() => FileMB;
}
