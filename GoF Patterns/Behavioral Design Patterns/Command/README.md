<h1 align="center">Command Design Pattern</h1>

**Command** is a behavioral design pattern that turns a request into a stand-alone object that contains all information about the request. This transformation lets you parameterize methods with different requests, delay or queue a request’s execution, and support undo operations.

## Problem
The **Command** pattern is primarily aimed at solving the problem of decoupling the requester of an operation from the object that performs the operation.

## Solution
It achieves this by encapsulating a request as an object, thereby allowing you to parameterize clients with different requests, queue or log requests, and support und operations.

the **Command** pattern addresses the following scenarios:
- Need for abstraction:
    - It provides a way to abstract and encapsulate a command or action, allowing clients to interact with it without knowing the specific details of the operation being performed.
    <br>
- Separation of concerns:
    - It decouples the object making the request (client) from the object implementing the request (receiver). This separation allows for greater flexibility, extensibility, and easier maintenance of the codebase.
    <br>
- Queue operations, schedule their execution, or execute them remotely:
    - As with any other object, a command can be serialized, which means converting it to a string that can be easily written to a file or a database. Later, the string can be restored as the initial command object. Thus, you can delay and schedule command execution. But there’s even more! In the same way, you can queue, log or send commands over the network.
    <br>
- Implement reversible operations:
    - Although there are many ways to implement undo/redo, the Command pattern is perhaps the most popular of all. <br>
    To be able to revert operations, you need to implement the history of performed operations. The command history is a stack that contains all executed command objects along with related
    backups of the application’s state. <br>
    This method has two drawbacks. First, it isn’t that easy to save an application’s state because some of it can be private. This problem can be mitigated with the **Memento** pattern. <br>
    Second, the state backups may consume quite a lot of RAM. Therefore, sometimes you can resort to an alternative implementation: instead of restoring the past state, the command performs the inverse operation. The reverse operation also has a price: it may turn out to be hard or even impossible to implement.

## Structure
<p align="center"><img width="500" alt="Command Pattern Structure" src="./ReadMe/Command-Pattern-Structure.png"></p>

- The **Sender** class (aka invoker) is responsible for initiating requests. This class must have a field for storing a reference to a command object. The sender triggers that command instead of sending the request directly to the receiver. Note that the sender isn’t responsible for creating the command object. Usually, it gets a pre-created command from the client via the constructor.

- The **Command** interface usually declares just a single method for executing the command.

- **Concrete Commands** implement various kinds of requests. A concrete command isn’t supposed to perform the work on its own, but rather to pass the call to one of the business logic objects. However, for the sake of simplifying the code, these classes can be merged. <br>
Parameters required to execute a method on a receiving object can be declared as fields in the concrete command. You can make command objects immutable by only allowing the initialization of these fields via the constructor.

- The **Receiver** class contains some business logic. Almost any object may act as a receiver. Most commands only handle the details of how a request is passed to the receiver, while the receiver itself does the actual work.

- The **Client** creates and configures concrete command objects. The client must pass all of the request parameters, including a receiver instance, into the command’s constructor. After that, the resulting command may be associated with one or multiple senders.

## Pros
- **Single Responsibility Principle**. You can decouple classes that invoke operations from classes that perform these operations.
- **Open/Closed Principle**. You can introduce new commands into the app without breaking existing client code.
- You can implement undo/redo.
- You can implement deferred execution of operations.
- You can assemble a set of simple commands into a complex one.

## Cons
- The code may become more complicated since you’re introducing a whole new layer between senders and receivers.