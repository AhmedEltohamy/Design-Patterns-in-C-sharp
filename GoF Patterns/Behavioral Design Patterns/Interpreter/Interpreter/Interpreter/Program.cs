using Interpreter;
using Interpreter.Expressions;

var context = new MathContext();
context.SetVariable("x", 2);
context.SetVariable("y", 3);

// 10 + 20 * (x + y)
var expression = new AddExpression(
    new NumberExpression(10),
    new MultiplyExpression(
        new NumberExpression(20),
        new AddExpression(
            new NumberExpression(context.GetVariable("x")),
            new NumberExpression(context.GetVariable("y"))
        )
    )
);

var result = expression.Interpret(context);

Console.WriteLine($"Result: {result}");

Console.ReadKey();