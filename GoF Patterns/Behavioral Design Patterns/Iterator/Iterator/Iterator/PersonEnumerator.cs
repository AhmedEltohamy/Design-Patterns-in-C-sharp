using System.Collections;

namespace Iterator;

internal class PersonEnumerator : IEnumerator<Person>
{
    private readonly Person[] _people;
    private int position = -1;

    public PersonEnumerator(People people)
    {
        if (people is null)
            throw new ArgumentNullException(nameof(people));

        _people = people.OrderBy(p => p.Name).ToArray();
    }

    public void Reset() => position = -1;

    public Person Current => _people[position];

    object IEnumerator.Current => Current;

    public bool MoveNext() => ++position < _people.Length;

    public void Dispose() 
    {
        // Empty
    }
}
