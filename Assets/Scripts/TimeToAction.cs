using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to standadise 'time to action' a little.
public class TimeToAction : MonoBehaviour
{
    public int eventTime;
    int modEventTime;
    public int currentTime;
    public bool usePropCurve;   

    public GameObject timerRectPrefab;
    GameObject timerRect;
    public AnimationCurve propCurve;


    void Start()
    {
        modEventTime = eventTime; //Mod event time is time as modified by random element.
        timerRect = Instantiate(timerRectPrefab,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        ResetTime();
    }

    private void Update() {
        if (timerRect != null && timerRect.activeInHierarchy){
            timerRect.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, 100));
        }
    }
    private void FixedUpdate()
    {
        if (currentTime < 0)
        {
            ResetTime();
        }
        Decriment();
    }

    private void Decriment(){
        currentTime -= 1;
        if (timerRect != null && timerRect.activeInHierarchy){
            timerRect.GetComponent<Slider>().value = currentTime;
        }
    }
    private void ResetTime(){
        currentTime = modEventTime + 1;
        // If probability range is being used;
        if (usePropCurve)
        {
            modEventTime = eventTime * Mathf.CeilToInt(propCurve.Evaluate(Random.value));
            Debug.Log($"Modified event time is {modEventTime}");
        }
        if (timerRect != null && timerRect.activeInHierarchy){
            timerRect.GetComponent<Slider>().maxValue = modEventTime;
        }
    }
}

