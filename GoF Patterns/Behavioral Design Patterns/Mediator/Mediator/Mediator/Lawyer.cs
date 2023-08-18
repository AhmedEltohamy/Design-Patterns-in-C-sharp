namespace Mediator;

internal class Lawyer : TeamMember
{
    public Lawyer(string name) : base(name) { }

    public override void Receive(string from, string message)
    {
        Console.Write($"{nameof(Lawyer)} {Name} received: ");
        base.Receive(from, message);
    }
}
