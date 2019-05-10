using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatedStringReference : MonoBehaviour
{
    public StringReference result;

    public FloatReference seconds;
    
    // In editor use '\'. eg: "d\:hh\:mm\:ss" 
    public string format = "hh:mm:ss";

    void Update() {
        result.setValue(convertToPrettyTime(seconds.Value, format));
    }

    // format: 0 = seconds, 1 = minutes, 2 = hours, 3 = days
    public static string convertToPrettyTime(float seconds, string timeFormat) {
        System.TimeSpan t = System.TimeSpan.FromSeconds(seconds);
        return t.ToString(timeFormat);
    }

    public static string convertToMinuteString(float seconds) { 
        return convertToPrettyTime(seconds, "m:ss");
    }


}
