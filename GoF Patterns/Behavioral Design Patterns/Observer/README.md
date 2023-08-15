<h1 align="center">Observer Design Pattern</h1>

**Observer** is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing. Also known as: Publisher-Subscriber, Pub-Sub

## Problem
Imagine that you have two types of objects: a `Customer` and a `Store` . The customer is very interested in a particular brand of product (say, it’s a new model of the iPhone) which should become available in the store very soon.

The customer could visit the store every day and check product availability. But while the product is still en route, most of these trips would be pointless.

On the other hand, the store could send tons of emails (which might be considered spam) to all customers each time a new product becomes available. This would save some customers from endless trips to the store. At the same time, it’d upset other customers who aren’t interested in new products.

It looks like we’ve got a conflict. Either the customer wastes time checking product availability or the store wastes resources notifying the wrong customers.

## Solution
The object that has some interesting state is often called ***subject***, but since it’s also going to notify other objects about the changes to its state, we’ll call it ***publisher***. All other objects that want to track changes to the publisher’s state are called ***subscribers***.

The **Observer** pattern suggests that you add a subscription mechanism to the publisher class so individual objects can subscribe to or unsubscribe from a stream of events coming from that publisher. Fear not! Everything isn’t as complicated as it sounds. In reality, this mechanism consists of:
1. An array field for storing a list of references to subscriber objects
1. several public methods which allow adding subscribers to and removing them from that list.

Now, whenever an important event happens to the publisher, it goes over its subscribers and calls the specific notification method on their objects.

Real apps might have dozens of different subscriber classes that are interested in tracking events of the same publisher class. You wouldn’t want to couple the publisher to all of those classes. Besides, you might not even know about some of them beforehand if your publisher class is supposed to be used by other people.

That’s why it’s crucial that all subscribers implement the same interface and that the publisher communicates with them only via that interface. This interface should declare the notification method along with a set of parameters that the publisher can use to pass some contextual data along with the notification.


## Structure
<p align="center"><img width="500" alt="Observer Pattern Structure" src="./ReadMe/Observer-Pattern-Structure.png"></p>

- The **Publisher** issues events of interest to other objects. These events occur when the publisher changes its state or executes some behaviors. Publishers contain a subscription infrastructure that lets new subscribers join and current subscribers leave the list.

- The **Subscriber** interface declares the notification interface. In most cases, it consists of a single `update` method. The method may have several parameters that let the publisher pass some event details along with the update.

- **Concrete Subscribers** perform some actions in response to notifications issued by the publisher. All of these classes must implement the same interface so the publisher isn’t coupled to concrete classes. <br>
Usually, subscribers need some contextual information to handle the update correctly. For this reason, publishers often pass some context data as arguments of the notification method.The publisher can pass itself as an argument, letting subscriber fetch any required data directly.

- The **Client** creates publisher and subscriber objects separately and then registers subscribers for publisher updates.

## Pros
- **Open/Closed Principle**. You can introduce new subscriber classes without having to change the publisher’s code (and vice versa if there’s a publisher interface). - 

- You can establish relations between objects at runtime.

## Cons
- Subscribers are notified in random order.