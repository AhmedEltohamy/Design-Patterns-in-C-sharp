namespace Interpreter.Expressions;

// Non-terminal Expression
internal class DivideExpression : IMathExpression
{
    private readonly IMathExpression _left;
    private readonly IMathExpression _right;

    public DivideExpression(IMathExpression leftExpression, IMathExpression rightExpression)
    {
        _left = leftExpression;
        _right = rightExpression;
    }

    public int Interpret(MathContext mathContext) => _left.Interpret(mathContext) / _right.Interpret(mathContext);
}
