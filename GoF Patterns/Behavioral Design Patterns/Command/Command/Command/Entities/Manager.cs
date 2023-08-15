namespace Command.Entities;

internal class Manager : Employee
{
    private readonly List<Employee> _employees = new();

    public IReadOnlyList<Employee> Employees => _employees.AsReadOnly();

    public Manager(int id, string name) : base(id, name)
    {
    }

    public void AddEmployee(Employee employee)
    {
        if (employee is null) 
            throw new ArgumentNullException(nameof(employee));

        if (_employees.Any(e => e.Id == employee.Id))
            throw new InvalidOperationException($"Employee with id: {employee.Id} is alreay supervised.");

        _employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        if (!_employees.Any(e => e.Id == employee.Id))
            throw new InvalidOperationException($"Employee with id: {employee.Id} is not found.");

        _employees.Remove(employee);
    }
}
