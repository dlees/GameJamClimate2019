using System.Collections;
using System;


public class NumberConverter {
    private static BigNumberNotation notation = new SuffixNotation();
    public const string EXP_FORMAT_STRING = "g4";

    public static string getString(float valueToConvert) {
        return notation.getString(valueToConvert, "{0:F0}");
    }

    public static string getString(float valueToConvert, string formatString) {
        return notation.getString(valueToConvert, formatString);
    }

    // To fit String.format order standards
    public static string getString(string formatString, float valueToConvert) {
        return notation.getString(valueToConvert, formatString);
    }
}


public interface BigNumberNotation {
    string getString(float valueToConvert, string formatString);
}


public class SuffixNotation : BigNumberNotation {

    private static string[] suffix = new string[] { "", "k", "M", "B", "T", "q", "Q" }; // kilo, mega, giga, terra, penta, exa

    public string getString(float valueToConvert, string formatString) {
        int scale = 0;
        double pieceOfValue = valueToConvert;
        while (pieceOfValue >= 1000) {
            pieceOfValue /= 1000;
            scale++;
            if (scale >= suffix.Length)
                return valueToConvert.ToString(NumberConverter.EXP_FORMAT_STRING); // overflow, can't display number, fallback to exponential
        }
        if (valueToConvert < 1000) {
            return String.Format(formatString, pieceOfValue);
        }

        return String.Format(formatString, pieceOfValue.ToString("0.00") + suffix[scale]);

    }
}


public class ExpNotation : BigNumberNotation {

    public string getString(float value, string formatString) {
        string curFormatString = formatString;
        if (value > 10000) {
            curFormatString = "{0:" + NumberConverter.EXP_FORMAT_STRING + "}";
        }

        return String.Format(curFormatString, value);
    }
}