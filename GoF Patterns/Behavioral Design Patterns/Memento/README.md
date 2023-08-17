<h1 align="center">Memento Design Pattern</h1>

**Memento**is a behavioral design pattern that lets you save and restore the previous state of an object without revealing the details of its implementation and without violating encapsulation. 

## Problem
We need to provides a way to save the state of an object at a particular point in time and restore it later, effectively implementing undo and redo functionality or supporting checkpoints in an application.

The main problem that the Memento pattern solves is the need to save and restore the state of an object while keeping the details of the state representation hidden from other objects. It ensures that the object itself is responsible for managing its internal state, and other objects can interact with it without directly accessing or modifying its state.

## Solution
By using the Memento pattern, you can achieve the following benefits:

- Encapsulation: The Memento pattern promotes encapsulation by encapsulating the state within the Memento object. The `originator` object doesn't expose its internal state directly, ensuring that the state remains encapsulated and protected.

- State Management: The Memento pattern provides a structured way to manage the state of an object. It allows you to capture and store the state in a separate `Memento` object, which can be stored, passed between objects, or used to restore the object's state later on.

- Undo/Redo: The Memento pattern enables undo and redo functionality by allowing an object to save its state and restore it as needed. It provides a mechanism to revert to a previous state and recover from changes or actions performed on the object.

- Checkpoints and Recovery: The Memento pattern allows an application to create checkpoints at critical points and restore the state to a specific checkpoint if needed. This can be useful in scenarios where an application needs to recover from errors, handle exceptions, or provide a way to roll back to a known stable state.

Overall, the Memento pattern solves the problem of managing object state in a controlled and encapsulated manner, providing a way to capture, store, and restore the state as needed, while preserving the object's encapsulation and integrity.

## Structure

### Implementation based on nested classes
The classic implementation of the pattern relies on support for nested classes, available in many popular programming languages (such as C++, C#, and Java).

<p align="center"><img width="500" alt="Memento Pattern Structure (based on nested classes)" src="./ReadMe/Memento-Pattern-Structure(based on nested classes).png"></p>



- The `Originator` class can produce snapshots of its own state, as well as restore its state from snapshots when needed.

- The `Memento` is a value object that acts as a snapshot of the originator’s state. It’s a common practice to make the memento immutable and pass it the data only once, via the constructor.

- The `Caretaker` knows not only “when” and “why” to capture the originator’s state, but also when the state should be restored. <br>
A caretaker can keep track of the originator’s history by storing a stack of mementos. When the originator has to travel back in history, the caretaker fetches the topmost memento from the stack and passes it to the originator’s restoration method.

In this implementation, the memento class is nested inside the originator. This lets the originator access the fields and methods of the memento, even though they’re declared private. On the other hand, the caretaker has very limited access to the memento’s fields and methods, which lets it store mementos in a stack but not tamper with their state.

<hr>

### Implementation based on an intermediate interface
There’s an alternative implementation, suitable for programming languages that don’t support nested classes (PHP).

<p align="center"><img width="500" alt="Memento Pattern Structure (based on an intermediate interface)" src="./ReadMe/Memento-Pattern-Structure(based on an intermediate interface).png"></p>

In the absence of nested classes, you can restrict access to the memento’s fields by establishing a convention that caretakers can work with a memento only through an explicitly declared intermediary interface, which would only declare methods related to the memento’s metadata.

On the other hand, originators can work with a memento object directly, accessing fields and methods declared in the memento class. The downside of this approach is that you need to declare all members of the memento public.

<hr>

### Implementation with even stricter encapsulation
There’s another implementation which is useful when you don’t want to leave even the slightest chance of other classes accessing the state of the originator through the memento.

<p align="center"><img width="500" alt="Memento Pattern Structure(with even stricter encapsulation)" src="./ReadMe/Memento-Pattern-Structure(with even stricter encapsulation).png"></p>

This implementation allows having multiple types of originators and mementos. Each originator works with a corresponding memento class. Neither originators nor mementos expose their state to anyone.

Caretakers are now explicitly restricted from changing the state stored in mementos. Moreover, the caretaker class becomes independent from the originator because the restoration method is now defined in the memento class.

Each memento becomes linked to the originator that produced it. The originator passes itself to the memento’s constructor, along with the values of its state. Thanks to the close relationship between these classes, a memento can restore the state of its originator, given that the latter has defined the appropriate setters.

## Pros
- You can produce snapshots of the object’s state without violating its encapsulation.

- You can simplify the originator’s code by letting the caretaker maintain the history of the originator’s state.

## Cons
- The app might consume lots of RAM if clients create mementos too often.

- Caretakers should track the originator’s lifecycle to be able to destroy obsolete mementos.

- Most dynamic programming languages, such as PHP, Python and JavaScript, can’t guarantee that the state within the memento stays untouched.