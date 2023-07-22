# Composite Design Pattern
**Composite** is a structural design pattern that lets you compose objects into tree structures and then work with these structures as if they were individual objects.

## Problem
Using the Composite pattern makes sense only when the core model of your app can be represented as a tree.

For example, imagine that you have two types of objects: `Products` and `Boxes` . A `Box` can contain several `Products` as well as a number of smaller `Boxes` . These little `Boxes` can also hold some `Products` or even smaller `Boxes` , and so on.

<img width="500" alt="Complex Order" src="./ReadMe/Complex-Order.png">

Say you decide to create an ordering system that uses these classes. Orders could contain simple products without any wrapping, as well as boxes stuffed with products...and other boxes. How would you determine the total price of such an order?

You could try the direct approach: unwrap all the boxes, go over all the products and then calculate the total. That would be doable in the real world; but in a program, it’s not as simple as running a loop. You have to know the classes of `Products` and `Boxes` you’re going through, the nesting level of the boxes and other nasty details beforehand. All of this makes the direct approach either too awkward or even impossible.

## Solution
The **Composite** pattern suggests that you work with `Products` and `Boxes` through a common interface which declares a method for calculating the total price.

How would this method work? For a product, it’d simply return the product’s price. For a box, it’d go over each item the box contains, ask its price and then return a total for this box. If one of these items were a smaller box, that box would also start going over its contents and so on, until the prices of all inner components were calculated. A box could even add some extra cost to the final price, such as packaging cost.

The greatest benefit of this approach is that you don’t need to care about the concrete classes of objects that compose the tree. You don’t need to know whether an object is a simple product or a sophisticated box. You can treat them all the same via the common interface. When you call a method, the objects themselves pass the request down the tree.

## Structure

<img width="500" alt="Composite Pattern Structure" src="./ReadMe/Composite-Pattern-Structure.png">

- The **Component** interface describes operations that are common to both simple and complex elements of the tree.
- The **Leaf** is a basic element of a tree that doesn’t have sub-elements.<br>Usually, leaf components end up doing most of the real work, since they don’t have anyone to delegate the work to.
- The **Container** (aka composite) is an element that has sub-elements: leaves or other containers. A container doesn’t know the concrete classes of its children. It works with all sub-elements only via the component interface.<br>Upon receiving a request, a container delegates the work to its sub-elements, processes intermediate results and then returns the final result to the client.
- The **Client** works with all elements through the component interface. As a result, the client can work in the same way with both simple or complex elements of the tree.

## Pros
- You can work with complex tree structures more conveniently: use polymorphism and recursion to your advantage.
- **Open/Closed** Principle. You can introduce new element types into the app without breaking the existing code, which now works with the object tree.

## Cons
- It might be difficult to provide a common interface for classes whose functionality differs too much. In certain scenarios, you’d need to overgeneralize the component interface, making it harder to comprehend.