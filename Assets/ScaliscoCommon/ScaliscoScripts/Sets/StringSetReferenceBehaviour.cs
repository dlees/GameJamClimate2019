using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringSetReference : GenericReference<List<string>, StringSet, StringSetReferenceBehaviour> {
    public void Add(string str) {
        Value.Add(str);
    }

    public void Clear() {
        Value.Clear();
    }

    internal object Select(Func<object, object> p) {
        throw new NotImplementedException();
    }
}

public class StringSetReferenceBehaviour : MonoBehaviour, Valueable<List<string>> {
    public StringSetReference reference;

    public List<string> Value
    {
	    get 
	    {
            return reference.Value;
        }
	      set 
	    {
            reference.setValue(value);
	    }
    }
}
