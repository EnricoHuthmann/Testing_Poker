using System;
using System.Collections.Generic;

public class Pair
{
    private HashSet<KeyValuePair<string, int>> hashSet;

    public Pair(HashSet<KeyValuePair<string, int>> hashSet)
    {
        this.hashSet = hashSet;
    }

    public List<KeyValuePair<string, int>> GetCards()
    {
        List<KeyValuePair<string, int>> cards = new();

        foreach (var keyValuePair in hashSet)
        {
            cards.Add(keyValuePair);
        }
        return cards;
    }

    public int GetValue()
    {
        foreach (var keyValuePair in hashSet)
        {
            return keyValuePair.Value * 2;
        }

        return 0;
    }
}