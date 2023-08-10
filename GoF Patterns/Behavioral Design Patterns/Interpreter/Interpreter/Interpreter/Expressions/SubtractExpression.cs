namespace Interpreter.Expressions;

// Non-terminal Expression
internal class SubtractExpression : IMathExpression
{
    private readonly IMathExpression _left;
    private readonly IMathExpression _right;

    public SubtractExpression(IMathExpression leftExpression, IMathExpression rightExpression)
    {
        _left = leftExpression;
        _right = rightExpression;
    }

    public int Interpret(MathContext mathContext) => _left.Interpret(mathContext) - _right.Interpret(mathContext);
}
