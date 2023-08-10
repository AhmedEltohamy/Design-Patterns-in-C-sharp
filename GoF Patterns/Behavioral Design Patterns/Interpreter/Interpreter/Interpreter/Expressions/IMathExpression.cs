namespace Interpreter.Expressions;

internal interface IMathExpression
{
    int Interpret(MathContext mathContext);
}