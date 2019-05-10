using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StringToGameObjectMapEntry {
    public string key;
    public GameObject value;
}

[System.Serializable]
public class StringToGameObjectMap {
    public StringToGameObjectMapEntry[] stringToGameObjectMapEntries;

    private Dictionary<string, GameObject> map;
    public Dictionary<string, GameObject> Map {
        get {
            if (map == null) { setup(); }
            return map;
        }
    }

    private void setup() {
        map = new Dictionary<string, GameObject>(stringToGameObjectMapEntries.Length);
        foreach (var entry in stringToGameObjectMapEntries) {
            map[entry.key] = entry.value;
        }
    }
}

[System.Serializable]
public class StringToGameObjectMapReference : GenericReference<StringToGameObjectMap, StringToGameObjectMapBehaviour, StringToGameObjectMapSO> { }

public class StringToGameObjectMapBehaviour : MonoBehaviour, Valueable<StringToGameObjectMap>
{
   public StringToGameObjectMapReference map;

   public Dictionary<string, GameObject> Map
   {
       get {
            return map.Value.Map;
       }
   }

    public StringToGameObjectMap Value { get { return map; } set => throw new System.NotImplementedException(); }
}


public class StringToGameObjectMapSO : ScriptableObject, Valueable<StringToGameObjectMap> {
    public StringToGameObjectMapReference map;

    public Dictionary<string, GameObject> Map {
        get {
            return map.Value.Map;
        }
    }

    public StringToGameObjectMap Value { get { return map; } set => throw new System.NotImplementedException(); }
}