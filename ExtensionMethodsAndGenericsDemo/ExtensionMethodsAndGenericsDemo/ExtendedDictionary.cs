using System;
using System.Collections;
using System.Collections.Generic;

public class ExtendedDictionaryElement<T, U, V>
{
    public T Key { get; set; }
    public U Value1 { get; set; }
    public V Value2 { get; set; }

    public ExtendedDictionaryElement(T key, U value1, V value2)
    {
        Key = key;
        Value1 = value1;
        Value2 = value2;
    }
}
public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
{
    private Dictionary<T, ExtendedDictionaryElement<T, U, V>> dictionary;

    public ExtendedDictionary()
    {
        dictionary = new Dictionary<T, ExtendedDictionaryElement<T, U, V>>();
    }

    public void Add(T key, U value1, V value2)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
        }
        else
        {
            Console.WriteLine("Елемент з таким ключем вже існує.");
        }
    }

    public bool Remove(T key)
    {
        return dictionary.Remove(key);
    }

    public bool ContainsKey(T key)
    {
        return dictionary.ContainsKey(key);
    }

    public bool ContainsValue(U value1, V value2)
    {
        foreach (var element in dictionary.Values)
        {
            if (EqualityComparer<U>.Default.Equals(element.Value1, value1) &&
                EqualityComparer<V>.Default.Equals(element.Value2, value2))
            {
                return true;
            }
        }
        return false;
    }

    public ExtendedDictionaryElement<T, U, V> this[T key]
    {
        get
        {
            dictionary.TryGetValue(key, out var element);
            return element;
        }
    }

    public int Count => dictionary.Count;

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        return dictionary.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
