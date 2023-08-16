<h1 align="center">Iterator Design Pattern</h1>

**Iterator** is a behavioral design pattern that lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).

## Problem
Collections are one of the most used data types in programming. Nonetheless, a collection is just a container for a group of objects.

Most collections store their elements in simple ***lists***. However, some of them are based on ***stacks***, ***trees***, ***graphs*** and other
complex data structures.

But no matter how a collection is structured, it must provide some way of accessing its elements so that other code can use these elements. There should be a way to go through each element of the collection without accessing the same elements over and over.

This may sound like an easy job if you have a collection based on a list. You just loop over all of the elements. But how do you sequentially traverse elements of a complex data structure, such as a ***tree***? For example, one day you might be just fine with ***depth-first traversal*** of a tree. Yet the next day you might require ***breadth-first traversal***. And the next week, you might need something else, like random access to the tree elements.

Adding more and more traversal algorithms to the collection gradually blurs its primary responsibility, which is efficient data storage. Additionally, some algorithms might be tailored for a specific application, so including them into a generic collection class would be weird.

On the other hand, the client code that’s supposed to work with various collections may not even care how they store their elements. However, since collections all provide different ways of accessing their elements, you have no option other than to couple your code to the specific collection classes.

## Solution
The main idea of the **Iterator** pattern is to extract the traversal behavior of a collection into a separate object called an `Iterator`.

In addition to implementing the algorithm itself, an `Iterator` object encapsulates all of the traversal details, such as the current position and how many elements are left till the end. Because of this, several iterators can go through the same collection at the same time, independently of each other.

Usually, **iterators** provide one primary method for fetching elements of the collection. The client can keep running this method until it doesn’t return anything, which means that the iterator has traversed all of the elements.

All iterators must implement the same interface. This makes the client code compatible with any collection type or any traversal algorithm as long as there’s a proper iterator. If you need a special way to traverse a collection, you just create a new `iterator` class, without having to change the collection or the client.

## Structure
<p align="center"><img width="500" alt="Iterator Pattern Structure" src="./ReadMe/Iterator-Pattern-Structure.png"></p>

- The **Iterator interface** declares the operations required for traversing a collection: fetching the next element, retrieving the current position, restarting iteration, etc.

- **Concrete Iterators** implement specific algorithms for traversing a collection. The iterator object should track the traversal progress on its own. This allows several iterators to traverse the same collection independently of each other.

- The **Collection interface** declares one or multiple methods for getting iterators compatible with the collection. Note that the return type of the methods must be declared as the iterator interface so that the concrete collections can return various kinds of iterators.

- **Concrete Collections** return new instances of a particular concrete iterator class each time the client requests one.

- The **Client** works with both collections and iterators via their interfaces. This way the client isn’t coupled to concrete classes, allowing you to use various collections and iterators with the same client code.

## Pros
- ***Single Responsibility Principle***. You can clean up the client code and the collections by extracting bulky traversal algorithms into separate classes.

- ***Open/Closed Principle***. You can implement new types of collections and iterators and pass them to existing code without breaking anything.

- You can iterate over the same collection in parallel because each iterator object contains its own iteration state. <br>
For the same reason, you can delay an iteration and continue it when needed.

## Cons
- Applying the pattern can be an overkill if your app only works with simple collections.

- Using an iterator may be less efficient than going through elements of some specialized collections directly.