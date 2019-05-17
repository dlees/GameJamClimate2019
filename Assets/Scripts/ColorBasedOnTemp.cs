using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorBasedOnTemp : MonoBehaviour
{
    public FloatReference temp;
    public Image foregroundBar;
    public Color[] colors;

    void Update()
    {
        if (temp < .5) {
            foregroundBar.color = colors[0]; 
        } else
        if (temp < 1.5) {
            foregroundBar.color = colors[1];
        } else
        if (temp < 2) {
            foregroundBar.color = colors[2];
        } else
        if (temp < 3.5) {
            foregroundBar.color = colors[3];
        } else
       {
            foregroundBar.color = colors[4];
        }
    }
}
