namespace Composite.Entities;

internal class DirectoryItem : FileSystemItem
{
    public List<FileSystemItem> Items { get; } = new();

    public DirectoryItem(string name) : base(name)
    {
    }

    public void AddItem(FileSystemItem item) => Items.Add(item);

    public void RemoveItem(FileSystemItem item) => Items.Remove(item);

    public override int GetSizeInMB() => Items.Sum(i => i.GetSizeInMB());
}