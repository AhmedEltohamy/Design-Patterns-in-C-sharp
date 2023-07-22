namespace Strategy.Strategies;

internal class BubbleSortStrategy : ISortStrategy
{
    public void Sort(int[] arr)
    {
        int i, j, temp;
        int n = arr.Length;
        bool swapped;
        for (i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }
}