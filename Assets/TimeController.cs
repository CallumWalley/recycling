using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider;
    float lastTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale != 0)
            {
                lastTimeScale = Time.timeScale;
                slider.value = 0;
                SetTime();
            }
            else
            {
                slider.value = lastTimeScale;
                SetTime();
            }
            Debug.Log($"Timescale is {Time.timeScale}");
        }
    }
    public void SetTime()
    {
        Time.timeScale = slider.value;
    }
}
 