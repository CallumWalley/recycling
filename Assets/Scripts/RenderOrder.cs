using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {           
        gameObject.transform.Translate(new Vector3(0,0f,0.01f * ((-transform.position.x) + transform.position.y*2.1f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
