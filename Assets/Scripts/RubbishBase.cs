using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;

using UnityEngine;
using Materials;

public class RubbishBase : MonoBehaviour
{
    public Elements.ElementEnum element;
    public Element _element;
    
    public Forms.FormEnum form;
    //TODO: Hide with accessor
    public Form _form;

    //public GameObject UILayer;
    public GameObject stackInfoPrefab;
    GameObject stackInfo;

    [Range(0.0f, 1f)]
    public float dirtyness;
    static float pucHeight = 0.06f;
    void Start()
    {          
        // Replace enum with actual class.         
        _element = Elements.elementDict[element];
        _form = Forms.formDict[form];     
        
        transform.GetComponent<SpriteRenderer>().color = _element.pucColor;
    }

    // Update is called once per frame
    void Update()
    {   
        Place();// Doesn't need to be in fixedupdate. move later.
    }

    void OnMouseEnter()
    {     

        stackInfo = Instantiate(stackInfoPrefab,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        stackInfo.GetComponent<StackInfo>().refPuc = transform;
        // Instantiate()
        //Debug.Log($"my sibling index is {transform.GetSiblingIndex()}");
    }
    
    void OnMouseExit()
    {
        Destroy(stackInfo);
    }

    // Determines pseudo-vertical position.
    void Place(){
        float sindex = transform.GetSiblingIndex();
        transform.localPosition = new Vector3(0, sindex * pucHeight, -sindex);
    }

    void HiliteTile(){
        transform.GetComponent<SpriteRenderer>().color = HoverHilight(_element.pucColor);
    //     sprite_line.GetComponent<SpriteRenderer>().enabled = true;
    //     sprite_line.localPosition = new Vector3(sprite_line.localPosition.x, sprite_line.localPosition.y, sprite_line.localPosition.z - 10);
    }
    void UnHiliteTile(){
        transform.GetComponent<SpriteRenderer>().color = _element.pucColor;
        //sprite_line.GetComponent<SpriteRenderer>().enabled = false;
       // sprite_line.localPosition = new Vector3(sprite_line.localPosition.x, sprite_line.localPosition.y, sprite_line.localPosition.z + 10);        
    }
    Color HoverHilight(Color baseColor)
    {
        return new Color(Mathf.Clamp(baseColor.r + 0.1f, 0, 1), Mathf.Clamp(baseColor.g + 0.1f, 0, 1), Mathf.Clamp(baseColor.b + 0.1f, 0, 1), baseColor.a);
    }
}
