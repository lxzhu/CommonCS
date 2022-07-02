namespace CommonCS;
using System.Collections.Generic;
using System.Linq;
public static class MapReduceExtensions
{
    public static IReduceable<TKey, TElement> Map<TElement, TKey>(
        this TElement[] collection,
        Func<TElement, TKey> func)
    {
        var groups = collection.GroupBy(x => func(x));
        return new Reduceable<TKey, TElement>(groups);
    }

    public static IReduceable<TKey, TElement> Map<TElement, TKey>(
        this IEnumerable<TElement> collection,
         Func<TElement, TKey> func)
    {
        var groups = collection.GroupBy(x => func(x));
        return new Reduceable<TKey, TElement>(groups);
    }

    public static TResult Reduce<TElement, TResult>
    (
        this IEnumerable<TElement> collection,
        TResult initial,
        Func<TElement, TResult, TResult> func)
    {
        TResult result = initial;
        foreach (var element in collection)
        {
            result = func(element, result);
        }
        return result;
    }

    public static TResult Reduce<TElement, TResult>
    (
        this TElement[] collection,
        TResult initial,
        Func<TElement, TResult, TResult> func)
    {
        return collection.AsEnumerable<TElement>().Reduce(initial, func);
    }
}

