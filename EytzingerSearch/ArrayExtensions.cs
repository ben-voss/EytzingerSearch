namespace EytzingerSearch;

using System.Numerics;

public static class ArrayExtensions
{
    public static T[] EytzingerSort<T>(this T[] a)
    {
        var n = a.Length;

        var b = new T[n + 1];

        EytzingerSort(a, b, n);

        return b;
    }

    private static int EytzingerSort<T>(T[] a, T[] b, int n, int i = 0, int k = 1)
    {
        if (k <= n)
        {
            i = EytzingerSort(a, b, n, i, 2 * k);
            b[k] = a[i++];
            i = EytzingerSort(a, b, n, i, 2 * k + 1);
        }

        return i;
    }

    public static int EytzingerSearch<T>(this T[] array, T x) where T : IComparisonOperators<T, T, bool>
        => array.TryEytzingerSearch(x, out var index) ? index : -1;

    public static bool TryEytzingerSearch<T>(this T[] array, T x, out int index) where T : IComparisonOperators<T, T, bool>
    {
        int length = array.Length - 1;

        index = 1;
        while (index <= length)
        {
            index = (index << 1) + ((array[index] < x) ? 1 : 0);
        }

        index >>= BitOperations.TrailingZeroCount(~(uint)index) + 1;

        return index != 0 && array[index] == x;
    }
}
