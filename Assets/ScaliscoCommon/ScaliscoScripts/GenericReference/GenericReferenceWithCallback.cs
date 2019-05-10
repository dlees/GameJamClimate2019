using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericReferenceWithCallback<CONSTANT_TYPE, SO_TYPE, MB_TYPE, CALLBACK_TYPE>: Valueable<CONSTANT_TYPE>
    where SO_TYPE : Valueable<CONSTANT_TYPE>
    where MB_TYPE : Valueable<CONSTANT_TYPE>
    where CALLBACK_TYPE : SerializableCallback<CONSTANT_TYPE>
    {
    public enum Type {
        CONSTANT,
        SCRIPTABLE_OBJECT,
        MONO_BEHAVIOUR,
        CALLBACK
    };
    public Type chosenType = Type.CONSTANT;
    public CONSTANT_TYPE ConstantValue;
    public SO_TYPE scriptableObjectVariable;
    public MB_TYPE monoBehaviourVariable;
    public CALLBACK_TYPE callback;

    public GenericReferenceWithCallback() { }

    public GenericReferenceWithCallback(CONSTANT_TYPE value) {
        chosenType = Type.CONSTANT;
        ConstantValue = value;

        if (monoBehaviourVariable != null || scriptableObjectVariable != null) {
            Debug.Log("This reference type is constant, but has variables");
        }
    }

    public GenericReferenceWithCallback(MB_TYPE value) {
        chosenType = Type.MONO_BEHAVIOUR;
        monoBehaviourVariable = value;
    }

    public GenericReferenceWithCallback(SO_TYPE value) {
        chosenType = Type.SCRIPTABLE_OBJECT;
        scriptableObjectVariable = value;
    }

    public GenericReferenceWithCallback(CALLBACK_TYPE value) {
        chosenType = Type.CALLBACK;
        callback = value;
    }

    public GenericReferenceWithCallback(GenericReferenceWithCallback<CONSTANT_TYPE, SO_TYPE, MB_TYPE, CALLBACK_TYPE> value) {
        chosenType = value.chosenType;
        ConstantValue = value.Value;
        scriptableObjectVariable = value.scriptableObjectVariable;
        monoBehaviourVariable = value.monoBehaviourVariable;
        callback = value.callback;
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
                case Type.CALLBACK:
                    return callback.Invoke();
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
                Debug.LogError("Reference doesn't support setting Value");
                break;
        }
    }
    
    public static implicit operator CONSTANT_TYPE(GenericReferenceWithCallback<CONSTANT_TYPE, SO_TYPE, MB_TYPE, CALLBACK_TYPE> reference) {
        return reference.Value;
    }
}
