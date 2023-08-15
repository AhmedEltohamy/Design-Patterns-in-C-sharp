namespace Command.Entities;

internal class Employee
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
