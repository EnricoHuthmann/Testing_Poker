using System.Collections.Generic;

public class Pair
{
    public HashSet<KeyValuePair<string, int>> hashSet;

    public Pair(HashSet<KeyValuePair<string, int>> hashSet)
    {
        this.hashSet = hashSet;
    }
}