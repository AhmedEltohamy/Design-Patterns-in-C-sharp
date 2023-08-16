using System.Collections;

namespace Iterator;

internal class People : List<Person>, IEnumerable<Person>
{
    public new IEnumerator<Person> GetEnumerator() => new PersonEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
