namespace CommonCS;
using System.Collections.Generic;

public interface IReduceable<TKey, TElement>
{
    IEnumerable<KeyValuePair<TKey, TResult>>
    Reduce<TResult>(Func<TKey, IEnumerable<TElement>, TResult> func);

}

