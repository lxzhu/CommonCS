namespace CommonCS;
using System.Collections.Generic;
using System.Linq;

public class Reduceable<TKey, TElement> : IReduceable<TKey, TElement>
{
    private IEnumerable<IGrouping<TKey, TElement>> _groups;
    public Reduceable(IEnumerable<IGrouping<TKey, TElement>> groups)
    {
        this._groups = groups;
    }
    public IEnumerable<KeyValuePair<TKey, TResult>> Reduce<TResult>(
        Func<TKey, IEnumerable<TElement>, TResult> func)
    {
        foreach (var group in _groups)
        {
            var result = func(group.Key, group)!;
            yield return new KeyValuePair<TKey, TResult>(group.Key, result);
        }
    }
}

