# Decorator Design Pattern
**Decorator** is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.

## Problem
Extending a class is the first thing that comes to mind when you need to alter an object’s behavior. However, inheritance
has several serious caveats that you need to be aware of.
- Inheritance is static. You can’t alter the behavior of an existing object at runtime. You can only replace the whole object with another one that’s created from a different subclass.
- Subclasses can have just one parent class. In most languages, inheritance doesn’t let a class inherit behaviors of multiple classes at the same time.

The new behavior completely different from class behaviors which violates Single Responsibility Principle

## Solution
One of the ways to overcome these caveats is by using **Composition** instead of **Inheritance**. With **composition** one object has a reference to another and delegates it some work, whereas with inheritance, the object itself is able to do that work, inheriting the behavior from its superclass.

With **composition**, you can easily substitute the linked “helper” object with another, changing the behavior of the container at runtime. An object can use the behavior of various classes, having references to multiple objects and delegating them all kinds of work.

**Wrapper** is the alternative nickname for the Decorator pattern that clearly expresses the main idea of the pattern. A “wrapper” is an object that can be linked with some “target” object.

The **Wrapper** contains the same set of methods as the target and delegates to it all requests it receives. However, the wrapper
may alter the result by doing something either before or after it passes the request to the target.

When does a simple wrapper become the real decorator? As mentioned, the wrapper implements the same interface as the wrapped object. That’s why from the client’s perspective these objects are identical. Make the wrapper’s reference field accept

## Structure

<img width="500" alt="Decorator Pattern Structure" src="./ReadMe/Decorator.png">

1. The **Component** declares the common interface for both wrappers and wrapped objects.
1. **Concrete Component** is a class of objects being wrapped. It defines the basic behavior, which can be altered by decorators.
1. The **Base Decorator** class has a field for referencing a wrapped object. The field’s type should be declared as the component interface so it can contain both concrete components and decorators. The base decorator delegates all operations to the wrapped object.
1. **Concrete Decorators** define extra behaviors that can be added to components dynamically. Concrete decorators override methods of the base decorator and execute their behavior either before or after calling the parent method.

## Pros
- You can extend an object’s behavior without making a new subclass.
- You can add or remove responsibilities from an object at runtime.
- You can combine several behaviors by wrapping an object into multiple decorators.
- **Single Responsibility Principle**. You can divide a monolithic class that implements many possible variants of behavior into several smaller classes.

## Cons
- It’s hard to remove a specific wrapper from the wrappers stack.
- It’s hard to implement a decorator in such a way that its behavior doesn’t depend on the order in the decorators stack.
- The initial configuration code of layers might look pretty ugly.