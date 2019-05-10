using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ScaliscoAssetMenuStructure {

    [MenuItem("Assets/Create/Scalisco/FloatVariable", false, 0)]
    static void floatVariable() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<FloatVariable>();
    }

    [MenuItem("Assets/Create/Scalisco/RangedFloat", false, 1)]
    static void RangedFloat() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<RangedFloat>();
    }

    [MenuItem("Assets/Create/Scalisco/StringVariable", false, 2)]
    static void stringVarable() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<StringVariableSO>();
    }

    [MenuItem("Assets/Create/Scalisco/BoolFlag", false, 3)]
    static void BoolFlag() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<BoolFlag>();
    }

    [MenuItem("Assets/Create/Scalisco/GameObjectSet", false, 30)]
    static void GameObjectSet() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<GameObjectSet>();
    }

    [MenuItem("Assets/Create/Scalisco/ScriptableObjectSet", false, 31)]
    static void ScriptableObjectSet() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<ScriptableObjectSet>();
    }

    [MenuItem("Assets/Create/Scalisco/StringSet", false, 32)]
    static void StringSet() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<StringSet>();
    }

    [MenuItem("Assets/Create/Scalisco/GameEvent", false, 60)]
    static void GameEvent() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<GameEvent>();
    }
    
    [MenuItem("Assets/Create/Scalisco/ColorMap", false, 1000)]
    static void ColorMap() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<ColorMap>();
    }

    [MenuItem("Assets/Create/Scalisco/CompositeConditionSO", false, 90)]
    static void CompositeConditionSO() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<CompositeConditionSO>();
    }

    [MenuItem("Assets/Create/Scalisco/FloatReferenceComparatorSO", false, 91)]
    static void FloatReferenceComparatorSO() {
        ScaliscoAssetMenuStructure.createScriptableObjectAsset<FloatReferenceComparatorSO>();
    }

    public static void createScriptableObjectAsset<T>() where T : ScriptableObject{
        var asset = ScriptableObject.CreateInstance<T>();

        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path.Contains(".asset")) {
            string[] assetPathArray = path.Split('/');
            string selectedAssetName = assetPathArray[assetPathArray.Length - 1];
            path = path.Replace("/" + selectedAssetName, ""); 
        }
        path += "/Default" + typeof(T).ToString() + ".asset";

        ProjectWindowUtil.CreateAsset(asset, path);
    }
}
