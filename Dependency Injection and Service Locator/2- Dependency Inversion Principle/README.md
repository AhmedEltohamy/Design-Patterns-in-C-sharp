<h1 align="center">The Dependency Inversion Principle (DIP)</h1>

The ***Dependency Inversion Principle (DIP)*** is one of the five SOLID principles of object-oriented programming, and it focuses on the relationship between high-level and low-level modules or classes.

The Dependency Inversion Principle states:

1. High-level modules should not depend on low-level modules; both should depend on abstractions.
1. Abstractions should not depend on details; details should depend on abstractions.

In the context of C#, the Dependency Inversion Principle can be understood as follows:

- High-level modules: These modules represent the higher-level components or classes in the application. They define the overall behavior and orchestration of the system.

- Low-level modules: These modules represent the lower-level components or classes that implement specific functionalities or services.

By following the Dependency Inversion Principle, the code becomes more modular, testable, and flexible. It allows for better separation of concerns and promotes code reuse since the dependencies are decoupled from the high-level modules and can be easily replaced or mocked during testing.

### Let's take an example from the previous topic(IoC Principal)

We implemented the ***factory pattern*** to achieve ***IoC***. But, the `CustomerService` class uses the concrete `CustomerRepository` class. Therefore, it is still **tightly coupled**, even though we have inverted the dependent object creation to the `CustomerRepositoryFactory` class.

Let's use DIP on the `CustomerService` and `CustomerRepository` classes and make them more loosely coupled.

As per the DIP definition, a high-level module should not depend on low-level modules. Both should depend on abstraction. So, first, decide which is the high-level module (class) and the low-level module. A high-level module is a module which depends on other modules. In our example, `CustomerService` depends on the `CustomerRepository` class, so `CustomerService` is a high-level module and `CustomerRepository` is a low-level module. So, as per the first rule of DIP, `CustomerService` should not depend on the concrete `CustomerRepository` class, instead both classes should depend on abstraction.

So, in the attached code example. We implemented `ICustomerRepository` in the `CustomerRepository` class then we need to change our `CustomerRepositoryFactory` class which returns `ICustomerRepository` instead of the concrete `CustomerRepository` then we need to change the `CustomerService` class to use `ICustomerRepository` instead of the concrete `CustomerRepository` class.

Thus, we have implemented ***DIP*** in our example where a high-level module (`CustomerService`) and low-level module (`CustomerRepository`) are dependent on an abstraction (`ICustomerRepository`). Also, the abstraction (`ICustomerRepository`) does not depend on details (`CustomerRepository`), but the details depend on the abstraction.

The advantages of implementing ***DIP*** in the attached code example is that the `CustomerService` and `CustomerRepository` classes are loosely coupled classes because `CustomerService` does not depend on the concrete `CustomerRepository` class, instead it includes a reference of the `ICustomerRepository` interface. So now, we can easily use another class which implements `ICustomerRepository` with a different implementation.

Still, we have not achieved fully loosely coupled classes because the `CustomerService` class includes a `CustomerRepositoryFactory` class to get the reference of `ICustomerRepository`. 