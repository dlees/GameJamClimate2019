using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Valueable<T> {
    T Value {
        get; set;
    }
}

public class GenericReference<CONSTANT_TYPE, SO_TYPE, MB_TYPE> : Valueable<CONSTANT_TYPE>
    where SO_TYPE : Valueable<CONSTANT_TYPE>
    where MB_TYPE : Valueable<CONSTANT_TYPE>
    {
    public enum Type {
        CONSTANT,
        SCRIPTABLE_OBJECT,
        MONO_BEHAVIOUR
    };
    public Type chosenType = Type.CONSTANT;
    public CONSTANT_TYPE ConstantValue;
    public SO_TYPE scriptableObjectVariable;
    public MB_TYPE monoBehaviourVariable;

    public GenericReference() { }

    public GenericReference(CONSTANT_TYPE value) {
        chosenType = Type.CONSTANT;
        ConstantValue = value;

        if (monoBehaviourVariable != null || scriptableObjectVariable != null) {
            Debug.Log("This reference type is constant, but has variables");
        }
    }

    public GenericReference(MB_TYPE value) {
        chosenType = Type.MONO_BEHAVIOUR;
        monoBehaviourVariable = value;
    }

    public GenericReference(SO_TYPE value) {
        chosenType = Type.SCRIPTABLE_OBJECT;
        scriptableObjectVariable = value;
    }

    public GenericReference(GenericReference<CONSTANT_TYPE, SO_TYPE, MB_TYPE> value) {
        chosenType = value.chosenType;
        ConstantValue = value.Value;
        scriptableObjectVariable = value.scriptableObjectVariable;
        monoBehaviourVariable = value.monoBehaviourVariable;
    }

    public virtual CONSTANT_TYPE Value {
        get {
            switch (chosenType) {
                case Type.CONSTANT:
                    return ConstantValue;
                case Type.SCRIPTABLE_OBJECT:
                    return scriptableObjectVariable.Value;
                case Type.MONO_BEHAVIOUR:
                    return monoBehaviourVariable.Value;
                default:
                    return ConstantValue;
            }
        }
        set { setValue(value); }
    }

    public virtual void setValue(CONSTANT_TYPE value) {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue = value;
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.Value = value;
                break;
            case Type.MONO_BEHAVIOUR:
                monoBehaviourVariable.Value = value;
                break;
            default:
                ConstantValue = value;
                break;
        }
    }
    
    public static implicit operator CONSTANT_TYPE(GenericReference<CONSTANT_TYPE, SO_TYPE, MB_TYPE> reference) {
        return reference.Value;
    }
}
