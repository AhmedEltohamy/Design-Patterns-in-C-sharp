# Template Method Design Pattern
**Template Method** is a behavioral design pattern that defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.

## Problem
Imagine that you’re creating a data mining application that analyzes corporate documents. Users feed the app documents in various formats (PDF, DOC, CSV), and it tries to extract meaningful data from these docs in a uniform format. The first version of the app could work only with DOC files.

In the following version, it was able to support CSV files. A month later, you “taught” it to extract data from PDF files.

<img width="500" alt="Data Mining Classes" src="./ReadMe/Data-Mining-Classes.png">

At some point, you noticed that all three classes have a lot of similar code. While the code for dealing with various data formats was entirely different in all classes, the code for data processing and analysis is almost identical. Wouldn’t it be great to get rid of the code duplication, leaving the algorithm structure intact?

There was another problem related to client code that used these classes. It had lots of conditionals that picked a proper course of action depending on the class of the processing object. If all three processing classes had a common interface or a base class, you’d be able to eliminate the conditionals in client code and use polymorphism when calling methods on a processing object.

## Solution
The **Template Method** pattern suggests that you break down an algorithm into a series of steps, turn these steps into methods, and put a series of calls to these methods inside a single “template method.” The steps may either be `abstract`, or have some default implementation. To use the algorithm, the client is supposed to provide its own subclass, implement all abstract steps, and override some of the optional ones if needed (but not the template method itself).

<img width="500" alt="Abstract Data Miner Class" src="./ReadMe/Abstract-Data-Miner-Class.png">

As you can see, we’ve got two types of steps:
- abstract steps must be implemented by every subclass
- optional steps already have some default implementation, but still can be overridden if needed

There’s another type of step, called **hooks**. A **hook** is an optional step with an empty body. A template method would work even if a **hook** isn’t overridden. Usually, **hooks** are placed before and after crucial steps of algorithms, providing subclasses with additional extension points for an algorithm.

## Structure
<img width="500" alt="Template Method Pattern Structure" src="./ReadMe/Template-Method-Pattern-Structure.png">

- The **Abstract Class** declares methods that act as steps of an algorithm, as well as the actual template method which calls these methods in a specific order. The steps may either be declared `abstract` or have some default implementation.
- **Concrete Classes** can override all of the steps, but not the template method itself.

## Pros
- You can let clients override only certain parts of a large algorithm, making them less affected by changes that happen to other parts of the algorithm.
- You can pull the duplicate code into a superclass.

## Cons
- Some clients may be limited by the provided skeleton of an algorithm.
- You might violate the **Liskov Substitution Principle** by suppressing a default step implementation via a subclass.
- Template methods tend to be harder to maintain the more steps they have.