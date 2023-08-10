namespace Interpreter.Expressions;

// Terminal Expression
internal class NumberExpression : IMathExpression
{
    private readonly int _number;

    public NumberExpression(int number) => _number = number;

    public int Interpret(MathContext mathContext) => _number;
}
