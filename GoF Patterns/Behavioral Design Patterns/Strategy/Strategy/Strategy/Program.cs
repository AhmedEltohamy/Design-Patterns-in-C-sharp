using Strategy;
using Strategy.Strategies;

int[] arr1 = { 64, 34, 25, 12, 22, 11, 90 };
int[] arr2 = { 64, 34, 25, 12, 22, 11, 90 };

var arrayService = new ArrayService();

Console.WriteLine("Array 1 after sorting");
arrayService.ChangeSortStrategy(new BubbleSortStrategy());
arrayService.Sort(arr1);
PrintArray(arr1);

Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");

Console.WriteLine("Array 2 after sorting");
arrayService.ChangeSortStrategy(new MergeSortStrategy());
arrayService.Sort(arr2);
PrintArray(arr2);


Console.ReadKey();

static void PrintArray(int[] arr)
{
    foreach(int item in arr)
        Console.WriteLine(item);
}