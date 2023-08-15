namespace Command.Commands;

internal class CommandManager
{
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();

    public void Invoke(ICommand command)
    {
        if (command is null) 
            throw new ArgumentNullException(nameof(command));

        if (command.CanExecute())
        {
            command.Execute();
            _commands.Push(command);
        }
    }

    public void Undo()
    {
        if (_commands.Any())
            _commands.Pop().Undo();
    }

    public void UndoAll()
    {
        while (_commands.Any())
            _commands.Pop().Undo();
    }
}
