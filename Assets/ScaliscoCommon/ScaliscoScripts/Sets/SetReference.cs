using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DEPRECATED - Use GenericListenableListReference instead
public class SetReference<T> {

    public enum Type {
        CONSTANT,
        SCRIPTABLE_OBJECT,
//    GAME_OBJECT
    };

    public Type chosenType = Type.CONSTANT;
    public List<T> ConstantValue;
    public RuntimeSet<T> scriptableObjectVariable;
    public FloatVariable gameObjectVariable;

    public SetReference() { }

    public SetReference(List<T> value) {
        chosenType = Type.CONSTANT;
        ConstantValue = value;

        if (
//    gameObjectVariable != null || 
            scriptableObjectVariable != null) {
            Debug.Log("This reference type is constant, but has variables");
        }
    }
/*
    public SetReference(GameObjectVariable<CONSTANT_TYPE> value) {
        chosenType = Type.GAME_OBJECT;
        gameObjectVariable = value;
    }
    */
    public SetReference(RuntimeSet<T> value) {
        chosenType = Type.SCRIPTABLE_OBJECT;
        scriptableObjectVariable = value;
    }

    public SetReference(SetReference<T> value) {
        chosenType = value.chosenType;
        ConstantValue = value.Value;
        scriptableObjectVariable = value.scriptableObjectVariable;
//        gameObjectVariable = value.gameObjectVariable;
    }

    public List<T> Value {
        get {
            switch (chosenType) {
                case Type.CONSTANT:
                    return ConstantValue;
                case Type.SCRIPTABLE_OBJECT:
                    return scriptableObjectVariable.Items;
 //               case Type.GAME_OBJECT:
//                    return gameObjectVariable.Value;
                default:
                    return ConstantValue;
            }
        }
    }

    public void addItem(T item) {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue.Add(item);
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.Add(item);
                break;
 //           case Type.GAME_OBJECT:
 //               gameObjectVariable.Value = value;
  //              break;
            default:
                ConstantValue.Add(item);
                break;
        }
    }

    public static implicit operator List<T>(SetReference<T> reference) {
        return reference.Value;
    }
}
