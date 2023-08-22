<h1 align="center">Inversion of Control (IoC) principle</h1>

The **Inversion of Control (IoC) principle** is a fundamental concept in software development that promotes loose coupling and modular design. It is closely related to the ***Dependency Inversion Principle (DIP)*** and is often used in conjunction with ***dependency injection***.

It is used to invert different kinds of controls in object-oriented design to achieve loose coupling. Here, controls refer to any additional responsibilities a class has, other than its main responsibility. This include control over the flow of an application, and control over the flow of an object creation or dependent object creation and binding.

The ***IoC principle*** helps in designing loosely coupled classes which make them testable, maintainable and extensible. the application's components become more  independent, and reusable.


### Control Over the Dependent Object Creation

***IoC*** can also be applied when we create objects of a dependent class. First of all, let's understand what we mean by dependency here.

```
public class A
{
    private readonly B b;

    public A() => b = new B();

    public void Task1()
    {
        // do something here..
        b.SomeMethod();
        // do something here..
    }
}

public class B {
    public void SomeMethod()
    { 
        //doing something..
    }
}
```

In the above example, class `A` calls `b.SomeMethod()` to complete its `task1`. Class `A` cannot complete its task without class `B` and so you can say that "Class `A` is dependent on class `B`" or "class `B` is a dependency of class `A`".

In the object-oriented design approach, classes need to interact with each other in order to complete one or more functionalities of an application, such as in the above example - classes `A` and `B`. Class `A` creates and manages the life time of an object of class `B`. Essentially, it **controls** the creation and life time of objects of the dependency class.

The ***IoC principle*** suggests to **invert the control**. This means to delegate the control to another class. In other words, invert the **dependency creation control** from class `A` to another class, as shown below.

```
public class A
{
    B b;

    public A() => b = Factory.GetObjectOfB ();

    public void Task1()
    {
        // do something here..
        b.SomeMethod();
        // do something here..
    }
}

public class B {
    public void SomeMethod()
    { 
        //doing something..
    }
}

public class Factory
{
    public static B GetObjectOfB() 
    {
        return new B();
    }
}
```

### Design Pattern That Implement the IoC Principle

- Factory
- Service Locator
- Dependency Injection
- Abstract Factory


### Code Example

As you can see in the attached code example, the `CustomerService` class uses the `CustomerRepositoryFactory.GetCustomerRepository()` method to get an object of the `CustomerRepository` class instead of creating it using the `new` keyword. Thus, we have **inverted the control of creating an object** of a dependent class from the `CustomerService` class to the `CustomerRepositoryFactory` class.