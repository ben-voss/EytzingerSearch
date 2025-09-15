namespace EytzingerSearch.Benchmarks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public /*sealed*/ class Benchmark
{
    private readonly int[] _sortedArray;
    private readonly int[] _eytzingerSortedArray;

    public Benchmark()
    {
        var myArray = new int[1 << 20];

        for (var i = 0; i < myArray.Length; i++)
        {
            myArray[i] = i + 1;
        }

        _sortedArray = myArray;
        _eytzingerSortedArray = myArray.EytzingerSort();
    }

    [Benchmark]
    public void TestBinarySearch()
    {
        var myArray = _sortedArray;

        for (var i = 0; i < myArray.Length; i++)
        {
            Array.BinarySearch(myArray, 0, myArray.Length, i);
        }
    }

    [Benchmark]
    public void TestEytzingerSearch()
    {
        var eytzingerSorted = _eytzingerSortedArray;

        for (var i = 0; i < eytzingerSorted.Length; i++)
        {
            eytzingerSorted.EytzingerSearch(i);
        }
    }

    [Benchmark]
    public void TestTryEytzingerSearch()
    {
        var eytzingerSorted = _eytzingerSortedArray;

        for (var i = 0; i < eytzingerSorted.Length; i++)
        {
            eytzingerSorted.TryEytzingerSearch(i, out var _);
        }
    }

    public class Program
    {
        // Run with 'dotnet run -c Release' from the console
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
