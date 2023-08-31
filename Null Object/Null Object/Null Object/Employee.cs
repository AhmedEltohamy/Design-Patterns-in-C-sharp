namespace Null_Object;

internal class Employee : IEmployee
{
    public int Id { get; protected set; }

    public string Name { get; protected set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string GetInfo() =>
        $"Employee: {Environment.NewLine}Id: {Id} {Environment.NewLine}Name: {Name} {Environment.NewLine}";
}
