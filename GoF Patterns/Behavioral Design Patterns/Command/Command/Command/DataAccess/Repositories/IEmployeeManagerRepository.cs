using Command.Entities;

namespace Command.DataAccess.Repositories;

internal interface IEmployeeManagerRepository
{
    IReadOnlyList<Manager> GetAll();
    void AddEmployee(int managerId, Employee employee);
    void RemoveEmployee(int managerId, Employee employee);
    bool HasEmployee(int managerId, int employeeId);
}
