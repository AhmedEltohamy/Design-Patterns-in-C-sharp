using Iterator;

var people = new People()
{
    new Person("Mohamed"),
    new Person("Yasser"),
    new Person("Ahmed"),
};

var enumerator = people.GetEnumerator();
while (enumerator.MoveNext())
{
    var person = enumerator.Current;
    Console.WriteLine(person.Name);
}

Console.WriteLine("********************************************");

foreach (var person in people)
    Console.WriteLine(person.Name);

Console.ReadKey();