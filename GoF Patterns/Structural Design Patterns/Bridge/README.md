# Bridge Design Pattern
**Bridge** is a structural design pattern that lets you split a large class or a set of closely related classes into two separate
hierarchies—abstraction and implementation—which can be developed independently of each other.

## Problem
Say you have a geometric `Shape` class with a pair of subclasses: `Circle` and `Square` . You want to extend this class hierarchy to incorporate colors, so you plan to create `Red` and `Blue` shape subclasses. However, since you already have two subclasses, you’ll need to create four class combinations such as `BlueCircle` and `RedSquare`.

<img width="500" alt="Shape Hierarchy" src="./ReadMe/Shape-Hierarchy.png">

Adding new shape types and colors to the hierarchy will grow it exponentially. For example, to add a triangle shape you’d need to introduce two subclasses, one for each color. And after that, adding a new color would require creating three subclasses, one for each shape type. The further we go, the worse it becomes.

This problem occurs because we’re trying to extend the shape classes in two independent dimensions: by form and by color. That’s a very common issue with class inheritance.

## Solution
The Bridge pattern attempts to solve this problem by switching from inheritance to composition. What this means is that you extract one of the dimensions into a separate class hierarchy, so that the original classes will reference an object of the new hierarchy, instead of having all of its state and behaviors within one class.

<img width="500" alt="Shape-Color Hierarchy" src="./ReadMe/Shape-Color-Hierarchy.png">

Following this approach, we can extract the color-related code into its own class with two subclasses: `Red` and `Blue` . The `Shape` class then gets a reference field pointing to one of the color objects. Now the shape can delegate any color-related work to the linked color object. That reference will act as a bridge between the `Shape` and `Color` classes. From now on, adding new colors won’t require changing the shape hierarchy, and vice versa.

## Abstraction and Implementation
The GoF book1 introduces the terms **Abstraction** and **Implementation** as part of the **Bridge** definition. In my opinion, the terms sound too academic and make the pattern seem more complicated\ than it really is. Having read the simple example with shapes and colors, let’s decipher the meaning behind the GoF book’s scary words.

**Abstraction** (also called interface) is a high-level control layer for some entity. This layer isn’t supposed to do any real work on its own. It should delegate the work to the **implementation** layer (also called platform). Note that we’re not talking about interfaces or abstract classes from your programming language. These aren’t the same things.

## Structure
<img width="500" alt="Bridge Pattern Structure" src="./ReadMe/Bridge-Structure.png">

- The **Abstraction** provides high-level control logic. It relies on the implementation object to do the actual low-level work.
- The **Implementation** declares the interface that’s common for all concrete implementations. An abstraction can only communicate with an implementation object via methods that are declared here.<br> The abstraction may list the same methods as the implementation, but usually the abstraction declares some complex behaviors that rely on a wide variety of primitive operations declared by the implementation.
- **Concrete Implementations** contain platform-specific code.
- **Refined Abstractions** provide variants of control logic. Like their parent, they work with different implementations via the general implementation interface.
- Usually, the **Client** is only interested in working with the abstraction. However, it’s the client’s job to link the abstraction object with one of the implementation objects.

## Pros
- You can create platform-independent classes and apps.
- The client code works with high-level abstractions. It isn’t exposed to the platform details.
- **Open/Closed** Principle. You can introduce new abstractions and implementations independently from each other.
- **Single Responsibility** Principle. You can focus on high-level logic in the abstraction and on platform details in the implementation.

## Cons
- You might make the code more complicated by applying the pattern to a highly cohesive class.