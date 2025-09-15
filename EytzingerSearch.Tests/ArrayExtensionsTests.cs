using Shouldly;
using Xunit;

namespace EytzingerSearch.Tests;

public sealed class ArrayExtensionsTests
{
    private static int[] MakeTestArray()
    {
        var testArray = new int[15];

        for (var i = 0; i < testArray.Length; i++)
        {
            testArray[i] = i * 2;
        }

        return testArray.EytzingerSort();
    }

    [Fact]
    public void TestEytzingerSearchElementNotFound()
    {
        var eytzingerSorted = MakeTestArray();

        var result = eytzingerSorted.EytzingerSearch(42);
        result.ShouldBe(-1);

        result = eytzingerSorted.EytzingerSearch(1);
        result.ShouldBe(-1);

        result = eytzingerSorted.EytzingerSearch(-1);
        result.ShouldBe(-1);
    }

    [Fact]
    public void TestEytzingerSearchElementsFound()
    {
        var eytzingerSorted = MakeTestArray();

        for (var i = 0; i < eytzingerSorted.Length - 1; i++)
        {
            var result = eytzingerSorted.EytzingerSearch(i * 2);
            eytzingerSorted[result].ShouldBe(i * 2);
        }
    }

    [Fact]
    public void TestTryEytzingerSearchElementNotFound()
    {
        var eytzingerSorted = MakeTestArray();

        var result = eytzingerSorted.TryEytzingerSearch(42, out var index);
        result.ShouldBeFalse();

        result = eytzingerSorted.TryEytzingerSearch(1, out index);
        result.ShouldBeFalse();

        result = eytzingerSorted.TryEytzingerSearch(-1, out index);
        result.ShouldBeFalse();
    }

    [Fact]
    public void TestTryEytzingerSearchElementsFound()
    {
        var eytzingerSorted = MakeTestArray();

        for (var i = 0; i < eytzingerSorted.Length - 1; i++)
        {
            var result = eytzingerSorted.TryEytzingerSearch(i * 2, out var index);
            result.ShouldBeTrue();
            eytzingerSorted[index].ShouldBe(i * 2);
        }
    }
}