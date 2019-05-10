using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorMath {
    /// <summary>
    /// https://github.com/lordofduct/spacepuppy-unity-framework/blob/master/SpacepuppyBase/Utils/MathUtil.cs
    /// </summary>

    public const float EPSILON_SQR = 0.0000001f;
    public const float EPSILON = 0.0001f;

    public static bool IsNearZeroVector(this Vector3 v) {
        return FuzzyEqual(v.sqrMagnitude, 0f, EPSILON_SQR);
    }
    public static bool IsNearZeroVector(this Vector2 v) {
        return FuzzyEqual(v.sqrMagnitude, 0f, EPSILON_SQR);
    }
 
    public static bool FuzzyEquals(this Vector2 a, Vector2 b) {
        return FuzzyEqual(Vector3.SqrMagnitude(a - b), EPSILON_SQR);
    }

    public static bool FuzzyEquals(this Vector2 a, Vector2 b, float epsilon) {
        return FuzzyEqual(Vector3.SqrMagnitude(a - b), epsilon);
    }

    public static bool FuzzyEquals(this Vector3 a, Vector3 b) {
        return FuzzyEqual(Vector3.SqrMagnitude(a - b), EPSILON_SQR);
    }

    public static bool FuzzyEquals(this Vector3 a, Vector3 b, float epsilon) {
        return FuzzyEqual(Vector3.SqrMagnitude(a - b), epsilon);
    }

    public static bool FuzzyEqual(float a, float b, float epsilon) {
        return Mathf.Abs(a - b) < epsilon;
    }

    public static bool FuzzyEqual(float a, float b) {
        return FuzzyEqual(a, b, EPSILON);
    }
}
