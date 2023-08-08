# Chain of Responsibility Design Pattern
**Chain of Responsibility** is a behavioral design pattern that lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

## Problem
We're building part of an application, which validates a document. <br>
The first thing that needs to happen is ensure that the document's title is filled out. <br>
Up next, we've got a requirement that the document's last modified date must be less than 30 days old. <br>
Then, the document must be read and approved by the litigation department, <br>
after which it can be sent to the manager and approved there. Only after the manager has approved the document, <br>
it's considered valid and can be sent to the customer

That's a lot of conditional statements that need to evaluate to true before the document is considered approved and ready to send to a customer. The method that checks the document becomes bloated and hard to manage, and there is no easy way to reuse these checks in other parts of our code.


## Solution
The **Chain of Responsibility** pattern suggests intent is to avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. It does that by chaining the receiving objects and passing the request along the chain until an object handles it.

The idea is that we're going to put all these validations and approvals in objects of their own, handlers. <br>
So, we end up with an interface, say `IHandler`, which states that there should be a method to handle the incoming request. <br>
We could scope this to a document class, but using generics makes this more reusable, so that's what I'd suggest. <br>
As each handler can pass the request onto the next one, we also need to provide a way to set the next handler. <br>
That's the potential successor. For each of our validations, we have an implementation of this interface, a handler. <br>
So, we've got a `DocumentTitleHandler`, a `DocumentLastModifiedHandler`, a `DocumentApprovedByLitigationHandler`, and the `DocumentApprovedByManagementHandler`

What these handlers do is get the document passed into their Handle method and can then execute their part of the document validation. <br>
If the validation doesn't check out, we don't continue, but if it does, we can continue to the successor. <br>
Like that, the document flows through the chain. And, of course, we have a client that initiates the request. <br>
The client chains the handlers and provides it with a document to validate. 

### Notes
The Gang of Four book, you'd notice it's a bit more strict. In that interpretation, a request moves up the chain of handlers, and each handler simply checks whether it can handle that request or not. If it can't, nothing happens to the request except passing it on. And if it can handle it, it's handled and not passed on anymore. Both are valid implementations.

A prime example of the chain of responsibility pattern at work is how the ASP.NET Core request pipeline works. Essentially, you're chaining pieces of middleware that can handle and/or alter a request and potentially pass it on to another piece of middleware.

## Structure
<img width="500" alt="Chain of Responsibility Pattern Structure" src="./ReadMe/Chain of Responsibility-Pattern-Structure.png">

- The **Handler** declares the interface, common for all concrete handlers. It usually contains just a single method for handling requests, but sometimes it may also have another method for setting the next handler on the chain.
- The **Base Handler** is an optional class where you can put the boilerplate code that’s common to all handler classes.
    - Usually, this class defines a field for storing a reference to the next handler. The clients can build a chain by passing a handler to the constructor or setter of the previous handler. The class may also implement the default handling behavior: it can pass execution to the next handler after checking for its existence.
- **Concrete Handlers** contain the actual code for processing requests. Upon receiving a request, each handler must decide whether to process it and, additionally, whether to pass it along the chain. 
    - Handlers are usually self-contained and immutable, accepting all necessary data just once via the constructor.
- The **Client** may compose chains just once or compose them dynamically, depending on the application’s logic. Note that a request can be sent to any handler in the chain—it doesn’t have to be the first one.

## Pros
- You can control the order of request handling.
- **Single Responsibility Principle**. You can decouple classes that invoke operations from classes that perform operations.
- **Open/Closed Principle**. You can introduce new handlers into the app without breaking the existing client code. 

## Cons
- Some requests may end up unhandled.