using Command.Entities;

namespace Command.DataAccess.Repositories;

internal class EmployeeManagerRepository : IEmployeeManagerRepository
{
    private static readonly List<Manager> _managers = new List<Manager>()
    {
        new Manager(1, "Katie"),
        new Manager(2, "Geoff")
    };

    public void AddEmployee(int managerId, Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        var manager = _managers.FirstOrDefault(m => m.Id == managerId);
        if (manager is null)
            throw new InvalidOperationException($"Manager with id: {managerId} is not found.");

        manager.AddEmployee(employee);
    }

    public void RemoveEmployee(int managerId, Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        var manager = _managers.FirstOrDefault(m => m.Id == managerId);
        if (manager is null)
            throw new InvalidOperationException($"Manager with id: {managerId} is not found.");
        
        manager.RemoveEmployee(employee);
    }

    public bool HasEmployee(int managerId, int employeeId)
    {
        var manager = _managers.FirstOrDefault(m => m.Id == managerId);
        if (manager is null)
            throw new InvalidOperationException($"Manager with id: {managerId} is not found.");

        return manager.Employees.Any(e => e.Id == employeeId);
    }

    public IReadOnlyList<Manager> GetAll() => _managers.AsReadOnly();
}
