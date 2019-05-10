using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ContainerConverter {
    public static string keysToString<TValue>(Dictionary<string, TValue> dictionary) {
        return String.Join(",", dictionary.Keys.ToArray());
    }

    public static string[] toStringList<T>(List<T> list) {
        string[] stringList = new string[list.Count];
        int i = 0;
        list.ForEach(item=> stringList[i++] = item.ToString());
        return stringList;
    }
}
