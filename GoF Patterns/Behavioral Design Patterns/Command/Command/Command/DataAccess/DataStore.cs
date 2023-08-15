using Command.DataAccess.Repositories;

namespace Command.DataAccess;

internal static class DataStore
{
    public static void PrintStoreSnapshot(IEmployeeManagerRepository employeeManagerRepository)
    {
        if (employeeManagerRepository is null)
            throw new ArgumentNullException(nameof(employeeManagerRepository)); 

        foreach (var manager in employeeManagerRepository.GetAll())
        {
            Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
            if (manager.Employees.Any())
            {
                foreach (var employee in manager.Employees)
                    Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
            }
            else
                Console.WriteLine($"\t No employees.");
        }
        Console.WriteLine();
    }
}
