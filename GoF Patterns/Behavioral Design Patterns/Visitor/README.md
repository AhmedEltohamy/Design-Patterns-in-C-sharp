# Visitor Design Pattern
**Visitor** is a behavioral design pattern that lets you separate algorithms from the objects on which they operate.

## Problem
Imagine that your team develops an app which works with geographic information structured as one colossal graph.

Each node of the graph may represent a complex entity such as a city, but also more granular things like industries, sightseeing
areas, etc.

The nodes are connected with others if there’s a road between the real objects that they represent. Under the hood, each node type is represented by its own class, while each specific node is an object.

At some point, you ned to implement exporting the graph into XML format. At first, the job seemed pretty straightforward.
You planned to add an export method to each node class and then leverage recursion to go over each node of the graph, executing the export method. <br>
The solution was simple and elegant: thanks to polymorphism, you weren’t coupling the code which called the export method to concrete classes of nodes.

Unfortunately, ypu are not allowed to alter existing node classes, Because that the code was already in production and we didn’t want to risk breaking it because of a potential bug in your changes.

Besides, he questioned whether it makes sense to have the XML export code within the node classes. The primary job of these classes was to work with Geo-Data. The XML export behavior would look alien there. Which violates the **Single Responsibility** principle.

There was another reason for the refusal. It was highly likely that after this feature was implemented, product owner would ask you to provide the ability to export into a different format, or request some other weird stuff. This would force you to change those precious and fragile classes again.

## Solution
The **Visitor** pattern suggests that you place the new behavior into a separate class called visitor, instead of trying to integrate
it into existing classes. The original object that had to perform the behavior is now passed to one of the visitor’s methods as an argument, providing the method access to all necessary data contained within the object.

Now, what if that behavior can be executed over objects of different classes? For example, in our case with XML export, the actual implementation will probably be a little bit different across various node classes. Thus, the visitor class may define not one, but a set of methods, each of which could take arguments of different types, like this:

<pre>
class ExportVisitor implements Visitor is
    method doForCity(City c) { ... }
    method doForIndustry(Industry f) { ... }
    method doForSightSeeing(SightSeeing ss) { ... }
    // ...
</pre>

But how exactly would we call these methods, especially when dealing with the whole graph? These methods have different signatures, so we can’t use polymorphism. To pick a proper visitor method that’s able to process a given object, we’d need to check its class. Doesn’t this sound like a nightmare?

<pre>
foreach (Node node in graph)
{
    if (node instanceof City)
        exportVisitor.doForCity((City) node) 
    if (node instanceof Industry) 
        exportVisitor.doForIndustry((Industry) node) 
    // ...
}
</pre>

You might ask, why don’t we use method overloading? That’s when you give all methods the same name, even if they support different sets of parameters. Unfortunately, even assuming that our programming language supports it at all (as Java and C# do), it won’t help us. <br>
Since the exact class of a node object is unknown in advance, the overloading mechanism won’t be able to determine the correct method to execute. It’ll default to the method that takes an object of the base `Node` class.

However, the Visitor pattern addresses this problem. It uses a technique called **Double Dispatch**, which helps to execute the proper method on an object without cumbersome conditionals. <br>
Instead of letting the client select a proper version of the method to call, how about we delegate this choice to objects we’re passing to the visitor as an argument?

Since the objects know their own classes, they’ll be able to pick a proper method on the visitor less awkwardly. They “accept” a visitor and tell it what visiting method should be executed.

<pre>
// Client code
foreach (Node node in graph)
    node.accept(exportVisitor)

// City
class City is
    method accept(Visitor v) is
        v.doForNode(this)
    // ...

// Industry
    class Industry is
        method accept(Visitor v) is
            v.doForNode(this)
        // ...
</pre>

I confess. We had to change the node classes after all. But at least the change is trivial and it lets us add further behaviors
without altering the code once again.

Now, if we extract a common interface for all visitors, all existing nodes can work with any visitor you introduce into the app. If you find yourself introducing a new behavior related to nodes, all you have to do is implement a new visitor class.

## Structure
<img width="500" alt="Visitor Pattern Structure" src="./ReadMe/Visitor-Pattern Structure.png">

- The **Visitor interface** declares a set of visiting methods that can take concrete elements of an object structure as arguments. These methods may have the same names if the program is written in a language that supports overloading, but the type of their parameters must be different.
- Each **Concrete Visitor** implements several versions of the same behaviors, tailored for different concrete element classes.
- The **Element interface** declares a method for “accepting” visitors. This method should have one parameter declared with the type of the visitor interface.
- Each **Concrete Element** must implement the acceptance method. The purpose of this method is to redirect the call to the proper visitor’s method corresponding to the current element class. Be aware that even if a base element class implements this method, all subclasses must still override this method in their own classes and call the appropriate method on the visitor object.
- The **Client** usually represents a collection or some other complex object. Usually, clients aren’t aware of all the concrete element classes because they work with objects from that collection via some abstract interface.

## Pros
- **Open/Closed Principle**. You can introduce a new behavior that can work with objects of different classes without changing these classes.
- **Single Responsibility Principle**. You can move multiple versions of the same behavior into the same class.
- A visitor object can accumulate some useful information while working with various objects. This might be handy when you want to traverse some complex object structure, such as an object tree, and apply the visitor to each object of this structure.

## Cons
- You need to update all visitors each time a class gets added to or removed from the element hierarchy.
- Visitors might lack the necessary access to the private fields and methods of the elements that they’re supposed to work with.

### Read more about Visitor and Double Dispatch:
- [Visitor and Double Dispatch](https://refactoring.guru/design-patterns/visitor-double-dispatch)
- [Re-thinking the Visitor Pattern with the Double-Dispatch Approach](https://exceptionnotfound.net/rethinking-the-visitor-pattern-with-the-double-dispatch-approach/)
- [Double Dispatch in C# and DDD](https://ardalis.com/double-dispatch-in-c-and-ddd/)