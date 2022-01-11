using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to standadise 'time to action' a little.
public class TimeToAction : MonoBehaviour
{
    public int eventTime;
    int modEventTime;
    public int currentTime;
    public bool firing = false;
    public bool usePropCurve;   
    public AnimationCurve propCurve;


    void Start()
    {
        modEventTime = eventTime;
    }

    private void FixedUpdate()
    {
        firing = false;
        currentTime += 1;
        if (currentTime == modEventTime - 1)
        {
            currentTime = 0;
            // If probability range is being used;
            if (usePropCurve)
            {
                modEventTime = eventTime * 10 * Mathf.CeilToInt(propCurve.Evaluate(Random.value));
            }
        }
        firing = true;
    }
}

