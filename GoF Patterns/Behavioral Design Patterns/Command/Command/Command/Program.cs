using Command.Commands;
using Command.DataAccess;
using Command.DataAccess.Repositories;
using Command.Entities;

var commandManager = new CommandManager();
var repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Kevin")));
DataStore.PrintStoreSnapshot(repository);

commandManager.Undo();
DataStore.PrintStoreSnapshot(repository);

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(222, "Clara")));
DataStore.PrintStoreSnapshot(repository);

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Tom")));
DataStore.PrintStoreSnapshot(repository);

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Tom")));
DataStore.PrintStoreSnapshot(repository);

commandManager.UndoAll();
DataStore.PrintStoreSnapshot(repository);

Console.ReadKey();