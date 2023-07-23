# State Design Pattern
**State** is a behavioral design pattern that lets an object alter its behavior when its internal state changes. It appears as if the object changed its class.

## Problem
- How can an object change its behavior when its internal state changes?

- How state-specific behaviors can be defined in a way that states can be added without altering the behaviors of existing states?

States are usually implemented with lots of conditional operators (`if` or `switch`) that select the appropriate behavior depending on the current state of the object. Usually, this “state” is just a set of values of the object’s fields.

The biggest weakness of a states based on conditionals reveals itself once we start adding more and more states and state-dependent behaviors to the class.

Most methods will contain monstrous conditionals that pick the proper behavior of a method according to the current state.

Code like this is very difficult to maintain because any change to the transition logic may require changing state conditionals in every method.

The problem tends to get bigger as a project evolves. It’s quite difficult to predict all possible states and transitions at the design stage. Hence, a lean state built with a limited set of conditionals can grow into a bloated mess over time.

## Solution
The **State** pattern suggests that you create new classes for all possible states of an object and extract all state-specific
behaviors into these classes.

Instead of implementing all behaviors on its own, the original object, called **context**, stores a reference to one of the state objects that represents its current state, and delegates all the state-related work to that object.

To transition the context into another state, replace the active state object with another object that represents that new state. This is possible only if all state classes follow the same interface and the context itself works with these objects through
that interface.

## Structure

<img width="500" alt="State Pattern Structure" src="./ReadMe/State-Pattern-Structure.png">

- **Context** stores a reference to one of the concrete state objects and delegates to it all state-specific work. The context communicates with the state object via the state interface. The context exposes a setter for passing it a new state object.
- The **State** interface declares the state-specific methods. These methods should make sense for all concrete states because you don’t want some of your states to have useless methods that will never be called.
- **Concrete States** provide their own implementations for the state-specific methods. <br>
To avoid duplication of similar code across multiple states, you may provide intermediate abstract classes that encapsulate some common behavior. <br>
State objects may store a back reference to the context object. Through this reference, the state can fetch any required info from the context object, as well as initiate state transitions.
- Both **context** and **concrete states** can set the next state of the **context** and perform the actual state transition by replacing the state object linked to the **context**.

## Pros
- **Single Responsibility** Principle. Organize the code related to particular states into separate classes.
- **Open/Closed** Principle. Introduce new states without changing existing state classes or the context.
-  Simplify the code of the context by eliminating bulky state machine conditionals.

## Cons
- Applying the pattern can be overkill if a state machine has only a few states or rarely changes.

### Note
**State** pattern structure may look similar to the **Strategy** pattern, but there’s one key difference:
- In the State pattern, the particular states may be aware of each other and initiate transitions from one state to another.
- whereas strategies almost never know about each other.