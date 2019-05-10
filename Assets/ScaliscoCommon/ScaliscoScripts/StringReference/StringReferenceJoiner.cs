using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StringReferenceJoiner : MonoBehaviour {

    public StringReference result;
    public StringReference separator;
    public List<StringReference> operands;
	
	void Update () {
        result.setValue(string.Join(separator.Value, operands.Select(reference => reference.Value).ToArray()));
	}
}
