using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DefaultTile : TileBase
{

    public GameObject emptyStack; 

    public override void GetTileData(Vector3Int position, ITilemap tileMap, ref TileData tileData){
        tileData.gameObject = emptyStack;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
