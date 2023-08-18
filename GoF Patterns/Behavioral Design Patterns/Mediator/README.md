<h1 align="center">Mediator Design Pattern</h1>

Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

## Problem
the issue of tight coupling and complex interdependencies between objects in a system. As a system grows, the number of direct dependencies between objects can increase, leading to code that is difficult to understand, maintain, and extend.

## Solution
By using the **Mediator** pattern, you can achieve the following benefits:

- Decoupling: The **Mediator** pattern promotes loose coupling between objects by removing direct dependencies and establishing a central point of communication. Instead of objects directly interacting with each other, they communicate through the `mediator`. This reduces the dependencies and simplifies the relationships between objects.

- Centralized Control: The **Mediator** pattern provides a central `mediator` object that encapsulates the communication logic and coordination between objects. It acts as a hub or a facilitator, allowing objects to interact indirectly. This centralized control simplifies the management of complex interactions and improves the overall system structure.

- Simplified Communication: The **Mediator** pattern simplifies communication between objects by abstracting away the complexities of direct communication. Instead of objects having to know about and communicate with each other explicitly, they only need to know about the `mediator` interface or base class. This simplifies the communication logic and makes it more maintainable.

- Scalability and Extensibility: The **Mediator** pattern supports scalability and extensibility by allowing new objects to be easily added to the system. Since objects communicate through the `mediator`, adding a new object requires updating the `mediator` to handle the new interactions, rather than modifying existing objects. This makes the system more flexible and easier to extend.

- Encapsulation: The **Mediator** pattern encapsulates the communication and coordination logic within the `mediator` object. This allows objects to focus on their core responsibilities without being burdened by the details of how communication is managed. It promotes better encapsulation and separation of concerns.

Overall, the **Mediator** pattern solves the problem of complex interdependencies and tight coupling between objects by introducing a central `mediator` that manages and coordinates their communication. It promotes loose coupling, simplifies communication, and improves the maintainability and scalability of the system.

## Structure
<p align="center"><img width="500" alt="Mediator Pattern Structure" src="./ReadMe/Mediator-Pattern-Structure.png"></p>

- The **Mediator** defines the communication between colleagues, and it's typically an abstract‑based class, meaning it can't be instantiated directly, but must have another concrete class inherited. 

- The **Concrete Mediator** inherits from the base mediator and implements the communication that was essentially defined by the contract or base methods in the mediator.

-  A **Colleague** is typically an abstract base class that represents a related collection of objects. It references only its mediator and communicates with it.

- The **Concrete Colleagues** are simply different types of sub‑classes that inherit from the abstract colleague base class and defines specific behavior.

What you see here is a very close match to the canonical mediator pattern originally defined in the Gang of Four book. But remember, patterns can have many different variations. Patterns are just guide rails, not prescriptive implementation rules that are set in stone. So, for example, you could define a class to be some sort of mediator and another class to be some sort of colleague without the need for the mediator and colleague objects having to inherit from an abstract base class. And you'd have no problem convincing me that that's a valid mediator pattern.

## Pros
- **Single Responsibility Principle**. You can extract the communications between various components into a single place, making it easier to comprehend and maintain.

- **Open/Closed Principle**. You can introduce new mediators without having to change the actual components.

- You can reduce coupling between various components of a program.

- You can reuse individual components more easily.

## Cons
- Over time a mediator can evolve into a ***God Object***.