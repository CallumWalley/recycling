using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stack : MonoBehaviour
{
    BaseGrid baseGrid;
    Vector3Int sourcePosition;
    float pseudoHeight;

    void Start()
    {           
    //Ugly. To counteract base layer being very low.
        baseGrid = transform.parent.GetComponentInParent<BaseGrid>();
        sourcePosition = baseGrid.machineryTilemap.WorldToCell(transform.position);
        try{
            pseudoHeight=baseGrid.machineryTilemap.GetInstantiatedObject(sourcePosition).GetComponentInParent<PlaceableObject>().PseudoHeight();
        }catch{
            pseudoHeight = 0;
        }

        transform.Translate(new Vector3(0,pseudoHeight,-200)); //Should put at 700 overall

    }

    // Update is called once per frame
    void FixedUpdate()
    {   

    }
}
