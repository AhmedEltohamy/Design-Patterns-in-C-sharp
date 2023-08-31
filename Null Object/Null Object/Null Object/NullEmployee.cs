namespace Null_Object;

internal class NullEmployee : IEmployee
{
    public int Id => -1;

    public string Name => string.Empty;

    public string GetInfo() => string.Empty;
}
