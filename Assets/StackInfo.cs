using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackInfo : MonoBehaviour
{
    public Transform refPuc; 
    public Text infoName;
    public Text infoClean;
    public Text infoWeight;

    void Start() {
    }
    void Update()
    {   
        if (refPuc != null){
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, refPuc.position, null, out canvasPos);
            transform.position = Camera.main.WorldToScreenPoint(new Vector3(refPuc.position.x +0.5f, refPuc.position.y + 0.2f, 100));
            // Final position of marker above GO in world space
            infoName.text = refPuc.GetComponent<RubbishBase>()._element.displayName() + " " + refPuc.GetComponent<RubbishBase>()._form.namePlural;
            infoClean.text = refPuc.GetComponent<RubbishBase>().dirtyness.ToString();
            infoWeight.text = refPuc.GetComponent<RubbishBase>()._element.weight.ToString();
        }
    }
}
