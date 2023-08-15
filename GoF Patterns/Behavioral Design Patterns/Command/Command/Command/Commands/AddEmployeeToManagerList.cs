using Command.DataAccess.Repositories;
using Command.Entities;

namespace Command.Commands;

internal class AddEmployeeToManagerList : ICommand
{
    private readonly IEmployeeManagerRepository _employeeManagerRepository;
    private readonly int _managerId;
    private readonly Employee _employee;

    public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee employee)
    {
        if (employeeManagerRepository is null)
            throw new ArgumentNullException(nameof(employeeManagerRepository));

        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        _employeeManagerRepository = employeeManagerRepository;
        _managerId = managerId;
        _employee = employee;
    }

    public bool CanExecute() => !_employeeManagerRepository.HasEmployee(_managerId, _employee.Id);

    public void Execute() => _employeeManagerRepository.AddEmployee(_managerId, _employee);

    public void Undo() => _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
}
