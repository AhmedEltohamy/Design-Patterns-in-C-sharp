namespace Command.Commands;

internal interface ICommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}
