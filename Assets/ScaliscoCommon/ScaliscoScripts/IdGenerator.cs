using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Generates ID based on DateTime. 
 * In the future, we could create an interface over this, but no reason now
 */
public class IdGenerator : MonoBehaviour {

    public StringReference stringRef;

    public void generateID() {
        System.DateTime nowdateTime = System.DateTime.Now.ToUniversalTime();

        stringRef.setValue(nowdateTime.ToString("yyyyMMddHHmm"));
	}
	
}
