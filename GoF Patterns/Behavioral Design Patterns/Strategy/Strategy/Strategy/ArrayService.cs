using Strategy.Strategies;

namespace Strategy;

internal class ArrayService
{
    private ISortStrategy? _sortStrategy;

    public void Sort(int[] arr)
    {
        if (_sortStrategy is null)
            throw new InvalidOperationException();

        _sortStrategy?.Sort(arr);
    }

    public void ChangeSortStrategy(ISortStrategy sortStrategy)
    {
        if (sortStrategy is null)
            throw new ArgumentNullException(nameof(sortStrategy));

        _sortStrategy = sortStrategy; 
    }
}
