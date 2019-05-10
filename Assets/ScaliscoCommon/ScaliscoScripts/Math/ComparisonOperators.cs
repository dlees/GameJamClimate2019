using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatComparisonOperators : ComparisonOperators<float> {
    public FloatComparisonOperators(string operatorNameOrSymbol) : base(operatorNameOrSymbol) { }
}

[System.Serializable]
public class IntComparisonOperators : ComparisonOperators<int> { }

[System.Serializable]
public class DoubleComparisonOperators : ComparisonOperators<double> { }

//TODO: Unit Tests
public class ComparisonOperators<T> where T : System.IComparable {

    public enum ComparisonOperator {
        GREATER_THAN,
        LESS_THAN,
        GREATER_THAN_EQUAL_TO,
        LESS_THAN_EQUAL_TO,
        EQUALS
    }

    public ComparisonOperator operation;

    protected ComparisonOperators(){}

    public ComparisonOperators(string operatorNameOrSymbol) {
        switch (operatorNameOrSymbol) {
            case ">":
            case "GREATER_THAN":
                operation = ComparisonOperator.GREATER_THAN;
                break;
            case "<":
            case "LESS_THAN":
                operation = ComparisonOperator.LESS_THAN;
                break;

            case "=":
            case "EQUALS":
                operation = ComparisonOperator.EQUALS;
                break;

            case "<=":
            case "LESS_THAN_EQUAL_TO":
                operation = ComparisonOperator.LESS_THAN_EQUAL_TO;
                break;

            case ">=":
            case "GREATER_THAN_EQUAL_TO":
                operation = ComparisonOperator.GREATER_THAN_EQUAL_TO;
                break;

            default:
                throw new KeyNotFoundException(operatorNameOrSymbol + " is not a valid comparison operator name or symbol!");

        }
    }

    public bool compare(T compared, T comparedWith) {
        /* For quick reference:
         * CompareTo returns:
            Less than zero - This instance is less than value.
            Zero - This instance is equal to value.
            Greater than zero - This instance is greater than value.  
         */

        switch (operation) {
            case ComparisonOperator.GREATER_THAN:
                return compared.CompareTo(comparedWith) > 0;
            case ComparisonOperator.LESS_THAN:
                return compared.CompareTo(comparedWith) < 0;
            case ComparisonOperator.GREATER_THAN_EQUAL_TO:
                return compared.CompareTo(comparedWith) >= 0;
            case ComparisonOperator.LESS_THAN_EQUAL_TO:
                return compared.CompareTo(comparedWith) <= 0;
            case ComparisonOperator.EQUALS:
                return compared.CompareTo(comparedWith) == 0;
            default:
                return false;
        }
    }
}
 