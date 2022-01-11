using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCam : MonoBehaviour
{

    public float ScrollEdge;
    public Vector2 panSpeed;
    public Vector2 panScale;
    public Vector2 panClamp;


    public Vector2 camLimit;
    Vector2 camTrans;
    Vector2 camTransSpeed;
    float xval;
    float yval;
    // Update is called once per frame
    void Update()
    {

        // Push pan.
        // X


        if  (Input.mousePosition.x > Screen.width - ScrollEdge){
            xval =  Input.mousePosition.x - Screen.width + ScrollEdge;
        }else if(Input.mousePosition.x < ScrollEdge){
            xval = Input.mousePosition.x - ScrollEdge;
        }else{
            xval=0;
        }
        if  (Input.mousePosition.y > Screen.height - ScrollEdge){
            yval = Input.mousePosition.y - Screen.height + ScrollEdge;
        }else if(Input.mousePosition.y < ScrollEdge){
            yval = Input.mousePosition.y - ScrollEdge;
        }else{
            yval = 0;
        }
        camTrans = new Vector2(xval, yval);
        camTransSpeed = camTrans * panSpeed;
        //Input.GetAxis("PanEW")
        Camera.main.transform.Translate((Vector3)camTransSpeed);

    }
}
