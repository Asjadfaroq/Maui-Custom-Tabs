using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Custom_Tabs.CustomControls;
public class WeakDictionary<TKey, TValue> where TValue : class
{
    private readonly Dictionary<TKey, WeakReference<TValue>> _dictionary = new();

    public TValue this[TKey key]
    {
        get
        {
            if (_dictionary.TryGetValue(key, out var weakRef) && weakRef.TryGetTarget(out var value))
            {
                return value;
            }
            throw new KeyNotFoundException();
        }
        set
        {
            _dictionary[key] = new WeakReference<TValue>(value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        value = default;
        if (_dictionary.TryGetValue(key, out var weakRef))
        {
            if (weakRef.TryGetTarget(out value))
            {
                return true;
            }
            _dictionary.Remove(key);
        }
        return false;
    }
    public void Add(TKey key, TValue value)
    {
        _dictionary[key] = new WeakReference<TValue>(value);
    }
    public bool Remove(TKey key)
    {
        return _dictionary.Remove(key);
    }
    public void Clear() => _dictionary.Clear();

    public bool ContainsKey(TKey key)
    {
        if (_dictionary.TryGetValue(key, out var weakRef))
        {
            if (weakRef.TryGetTarget(out _))
            {
                return true;
            }
            _dictionary.Remove(key);
        }
        return false;
    }
}