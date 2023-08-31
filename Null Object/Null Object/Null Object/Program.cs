using Null_Object;

while (true)
{
    Console.WriteLine("Please enter employee id: ");
    if (!int.TryParse(Console.ReadLine(), out var employeeId))
    {
        Console.WriteLine("Please enter valid id");
        continue;
    }

    var employee = new EmployeeRepository().GetEmployeeById(employeeId);
    Console.WriteLine(employee.GetInfo());
}