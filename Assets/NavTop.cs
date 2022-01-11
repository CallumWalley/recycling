using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavTop : MonoBehaviour
{
    public Text curStep;
    public Text rateStep;

    int stepCount = 0;

    void FixedUpdate() {
        stepCount +=1;
    }
    void Update()
    {
        curStep.text = stepCount.ToString();
        rateStep.text = Time.timeScale.ToString();
    }
}
