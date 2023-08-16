namespace Iterator;

internal class Person
{
    public string Name { get; private set; }

    public Person(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
    }   
}
