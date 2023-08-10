namespace Interpreter;

internal class MathContext
{
    private readonly Dictionary<string, int> _variables;

    public MathContext() => _variables = new Dictionary<string, int>();

    public void SetVariable(string name, int value) => _variables[name] = value;

    public int GetVariable(string name) => _variables[name];
}
