<h1 align="center">Dependency Injection Pattern</h1>

The ***Dependency Injection (DI)*** pattern is a design pattern commonly used in object-oriented programming. It facilitates loose coupling between components by allowing the dependencies of a class to be provided from the outside rather than being created internally.

### The Dependency Injection pattern can be understood as follows:

- **Dependencies**: Dependencies are external objects or services that a class relies on to perform its tasks or provide certain functionality. These dependencies can include other classes, interfaces, or even external resources like databases or web services.

- **Dependency Injection**: Dependency Injection is a technique used to provide the dependencies of a class from the outside. Instead of a class creating its own dependencies, they are "injected" into the class from an external source, typically through constructor parameters, properties, or method parameters.

- **Inversion of Control**: Dependency Injection is closely related to the ***Inversion of Control (IoC) principle***. By allowing dependencies to be injected, the control over object creation and lifecycle management is inverted or delegated to an external component or framework.

```
public interface IService
{
    void Execute();
}

public class Service : IService
{
    public void Execute() =>
        Console.WriteLine("Service executed.");
}

public class Client
{
    private readonly IService service;

    public Client(IService service) =>
        this.service = service;

    public void ExecuteService() =>
        service.Execute();
}

public class Program
{
    public static void Main()
    {
        IService service = new Service();
        Client client = new Client(service);
        client.ExecuteService();
    }
}
```

## Dependency Injection Types

Dependency Injection in C# can be implemented using several types or techniques. The most common types of Dependency Injection are:

### Constructor Injection

In constructor injection, dependencies are provided through a class's constructor parameters.

```
public class Client
{
    private readonly IService service;

    public Client(IService service) => 
        this.service = service;
}
```

### Property Injection

In property injection, dependencies are set through public properties of a class.

```
public class Client
{
    public IService Service { get; set; }
}
```

### Method Injection

In method injection, dependencies are passed as parameters to specific methods.

```
public class Client
{
    public void SetService(IService service)
    {
        // ...
    }
}
```

### Interface Injection

In interface injection, the class implements an interface that defines methods for setting dependencies.

```
public interface IDependencySetter
{
    void SetDependency(IService service);
}

public class Client : IDependencySetter
{
    public void SetDependency(IService service)
    {
        // ...
    }
}
```

Each type of Dependency Injection has its own advantages and considerations. **Constructor Injection** is generally considered the most preferred type as it enforces the dependency to be provided during object creation and ensures that the object is in a valid state. **Property and method injection** can be useful in scenarios where dependencies are optional or can be changed dynamically. **Interface injection** is less common and is typically used in specific situations where flexibility in dependency injection is required.

### Let's take an example from the previous topics(IoC and DIP using Factory and Service Locator Design Patterns)

he problem with the above example is that we used `CustomerRepositoryFactory` or `ServiceLocator` inside the `CustomerService` class. So, suppose there is another implementation of `ICustomerRepository` and we want to use that new class inside `CustomerService`. Then, we need to change the source code of the `CustomerService` class as well. The ***Dependency injection pattern*** solves this problem by injecting dependent objects via a constructor, a property, or an interface.

So we will change `CustomerService` to include the constructor with one parameter of type `ICustomerRepository`. Now, the calling class must inject an object of `ICustomerRepository`.

- ***Note:*** See the attached code example after applying DI Pattern.