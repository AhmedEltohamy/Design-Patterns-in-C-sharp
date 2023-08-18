namespace Mediator;

internal abstract class TeamMember
{
    public string Name { get; }

    private IChatRoom? _chatroom;

    protected TeamMember(string name) 
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
    }

    public void SetChatroom(IChatRoom chatRoom) => _chatroom = chatRoom;

    public void Send(string message) => _chatroom?.Send(Name, message);

    public void Send(string to, string message) => _chatroom?.Send(Name, to, message);

    public void SendTo<T>(string message) where T : TeamMember =>
        _chatroom?.SendTo<T>(Name, message);

    public virtual void Receive(string from, string message) =>
        Console.WriteLine($"message from {from} to {Name}: {message}");
}
