namespace Null_Object;

internal class EmployeeRepository
{
    private static readonly IReadOnlyList<Employee> _employees = new List<Employee>()
    {
        new Employee(1, "Ahmed"),
        new Employee(2, "Hany"),
        new Employee(3, "Sayed")
    };

    public IEmployee GetEmployeeById(int id)
    {
        var employee = _employees.FirstOrDefault(x => x.Id == id);
        
        if (employee is null)
            return new NullEmployee();
        
        return employee;
    }

}
