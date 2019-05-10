using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSet : RuntimeSet<ScriptableObject> { }

[System.Serializable]
public class ScriptableObjectSetReference : SetReference<ScriptableObject> { }
