namespace Composite.Entities;

internal abstract class FileSystemItem
{
    public string Name { get; }

    protected FileSystemItem(string name) => Name = name;

    public abstract int GetSizeInMB();
}