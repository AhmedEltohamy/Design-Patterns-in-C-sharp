namespace Mediator;

using System.Linq;

internal class TeamChatRoom : IChatRoom
{
    private readonly Dictionary<string, TeamMember> _teamMembers = new();

    public void Register(TeamMember teamMember)
    {
        if (teamMember is null)
            throw new ArgumentNullException(nameof(teamMember));

        teamMember.SetChatroom(this);
        if (_teamMembers.ContainsKey(teamMember.Name))
            return;

        _teamMembers.Add(teamMember.Name, teamMember);
    }

    public void Send(string from, string message)
    {
        if (string.IsNullOrWhiteSpace(from))
            throw new ArgumentNullException(nameof(from));

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));

        foreach (var teamMember in _teamMembers.Values)
            teamMember.Receive(from, message);
    }

    public void Send(string from, string to, string message)
    {
        if (string.IsNullOrWhiteSpace(from))
            throw new ArgumentNullException(nameof(from));

        if (string.IsNullOrWhiteSpace(to))
            throw new ArgumentNullException(nameof(to));

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));

        if (_teamMembers.TryGetValue(to, out TeamMember teamMember)) ;
            teamMember?.Receive(from, message);
    }

    public void SendTo<T>(string from, string message) where T : TeamMember
    {
        if (string.IsNullOrWhiteSpace(from))
            throw new ArgumentNullException(nameof(from));

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));

        foreach (var teamMember in _teamMembers.Values.OfType<T>())
            teamMember.Receive(from, message);
    }
}
