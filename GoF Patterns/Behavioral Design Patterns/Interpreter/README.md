<h1 align="center">Interpreter Design Pattern</h1>

**Interpreter** is a behavior pattern that allows you to build an interpreter for a simple language and specifies how to evaluate sentences or expressions in that language.

## Problem
Need to defines the grammar of the language and provides a way to evaluate the grammar.

## Solution
Typically, the grammar consists of a set of `classes`, each of which represents a rule in the grammar. The interpreter pattern combines the rules to form a hierarchy with the most basic rules at the bottom and the more complex rules at the top,
that interface.

For example, the following picture illustrates an expression 10 + 20 * (2 + 3) as a tree of rules:

<p align="center"><img width="200" alt="Example 1" src="./ReadMe/Example 1.svg"></p>

To evaluate a sentence or expression, the interpreter takes input and applies the grammar rules to it. More specifically, the interpreter recursively evaluates the rules, applies the most basic rules first, and combines the result of each evaluation until the entire sentence or expression is evaluated.

The result of the evaluation is typically a value or a set of values, depending on the specific application of the interpreter.

## Structure
<p align="center"><img width="500" alt="Interpreter Pattern Structure" src="./ReadMe/Interpreter-Pattern-Structure.png"></p>

- **AbstractExpression** is an abstract class or an interface that has `interpret()` method for evaluating the expression.
- **TerminalExpression** is a concrete implementation of the abstract expression. The **TerminalExpression** represents the simplest elements of the grammar such as variables, constants, or literals. A terminal expression cannot be further decomposed into smaller expressions. For example, in an arithmetic expression grammar, a terminal expression could be a number or a variable.
- **NonTerminalExpression** represents the more complex elements of the language grammar built from simpler expressions. Unlike a terminal expression, a non-terminal expression can be decomposed into smaller expressions until they reach terminal expressions. For example, in an arithmetic expression grammar, a non-terminal expression could represent a binary operation such as addition, which is built from two terminal expressions.
- **Context** is the context in that the interpreter evaluates the expression. It contains the information required for the evaluation of the expression.
- **Client** is a class that is responsible for building an expression using the **TerminalExpression** and **NonTerminalExpression**. It passes the expression to the interpreter for evaluation.

For example, the following picture shows the terminal and non-terminal expressions:

<p align="center"><img width="200" alt="Example 2" src="./ReadMe/Example 2.svg"></p>

## Pros
- It's easy to change and extend the grammar
- **Open/Closed** Principle. We can extend the grammar. Grammar rules are represented by classes, and these can be extended via inheritance.

## Cons
- Complex grammars are hard to maintain. There's at least one class for every rule in the grammar. So, if you've got a large set of rules, you've got a large set of classes to manage and maintain.