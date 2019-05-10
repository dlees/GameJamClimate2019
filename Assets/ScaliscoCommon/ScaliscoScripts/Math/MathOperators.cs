using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We must use enum/switch here because Unity doesn't support 
// Polymorphism of Serializable objects :(
[System.Serializable]
public class MathOperator {

    public enum OperatorType { ADD, MULTIPLY, SUBTRACT, LOG, FLOOR };
    public OperatorType operatorType;

    public static Dictionary<string, string> nicknameToOperatorName = new Dictionary<string, string> {
        { "gain", "add"},
        { "add", "add"},
        { "lose", "subtract"},
        { "multiply", "multiply"},
        { "subtract", "subtract"}
    };

    private Dictionary<string, OperatorType> symbolToOperator = new Dictionary<string, OperatorType> {
        {"+", OperatorType.ADD},
        {"-", OperatorType.SUBTRACT},
        {"*", OperatorType.MULTIPLY},
        {"log", OperatorType.LOG },
        {"floor", OperatorType.FLOOR }
    };

    public MathOperator(string operatorSymbol) {
        try {
            operatorType = symbolToOperator[operatorSymbol];
        } catch (KeyNotFoundException e) {
            Debug.LogError(operatorSymbol + " is not a valid operator!");
            throw e;
        }
    }

    public float getResult(List<FloatReference> operands) {
        switch (operatorType)
        {
            case OperatorType.ADD:
		        float tempResult = 0;
		        foreach (FloatReference operand in operands) {
			        tempResult += operand;
		        }
		        return tempResult;

            case OperatorType.SUBTRACT:
                tempResult = operands[0];
                for (int i = 1; i < operands.Count; i++) {
                    tempResult -= operands[i];
                }
                return tempResult;

            case OperatorType.MULTIPLY:
                tempResult = 1;
		        foreach (FloatReference operand in operands) {
			        tempResult *= operand;
		        }
		        return tempResult;

            // Assumes 0 is the log base, and 1 is the operand
            case OperatorType.LOG:
                tempResult = Mathf.Log(operands[1], operands[0]);
                return tempResult;

            case OperatorType.FLOOR:
                tempResult = Mathf.Floor(operands[0]);
                return tempResult;

            default:
                throw new KeyNotFoundException("No Operator Definition Exists for " + operatorType.ToString());
        }
    }

}
