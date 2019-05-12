using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRateCalculator : MonoBehaviour
{
    public FloatReference temp;
    public FloatReference tempRateResult;
    public FloatReference oilPrice;

    public float initialIncreasePerMin = .5f;


    // Update is called once per frame
    void Update()
    {
        tempRateResult.Value = initialIncreasePerMin * oilPrice.Value / 980;
        temp.Value += tempRateResult.Value/ 60 * Time.deltaTime;
    }
}
