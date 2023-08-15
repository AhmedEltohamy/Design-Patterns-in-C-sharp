using Observer.Observers;

namespace Observer.Subjects;

internal interface ISubject
{
    void RegisterObserver(IProductObserver observer);
    void RemoveObserver(IProductObserver observer);
    void NotifyObservers(string newProduct);
}
