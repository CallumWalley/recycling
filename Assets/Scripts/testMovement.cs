using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float tilesize = 1f;
    float translationX;
    float translationY;

    Tilemap tilemap;
    void Start()
    {
        tilemap = transform.GetComponentInParent<Tilemap>();
    }
    private Vector3 screenPoint;
    private Vector3 offset;
    Vector3 curPosition;
    Vector3 curScreenPoint;

    public GameObject dragGhostPrefab;
    GameObject dragGhost;
     
    void OnMouseDown()
    {
        // foreach ( SpriteRenderer childSprite in dragGhost.GetComponentsInChildren<SpriteRenderer>()) {
        //     childSprite.color = new Color(childSprite.color.r, childSprite.color.g, childSprite.color.b, 0.2f);
        // }
        dragGhost = Instantiate(dragGhostPrefab);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y ,0));
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        dragGhost.transform.parent = gameObject.transform;
        dragGhost.transform.position = curPosition;
    }
 
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        dragGhost.transform.position = curPosition;
    }

    void OnMouseUp(){

        Vector3Int tilePosition = tilemap.WorldToCell(dragGhost.transform.position);
        //Tile.GetTileData(tilePosition, null, ref null);
        //tile.GetTileData
        //Tile.GetTileData(tilePosition, null, ref tempdata);
        //transform.parent = tile.
        try{
            // Tiles _objects_ should all be at 0 elevation. 
            Transform newStack = tilemap.GetInstantiatedObject(new Vector3Int(tilePosition.x,tilePosition.y,0)).transform;
            gameObject.transform.parent = newStack;
            gameObject.transform.localPosition = new Vector3(0,0,0);
        }catch(NullReferenceException e){
            Debug.Log(e);
        }

        Destroy(dragGhost);
    }

    // Update is called once per frame
    void Update()
    {   
        //Mathf.Round
        // translationY = (Input.GetAxisRaw("Vertical"));
        // translationX = (Input.GetAxisRaw("Horizontal"));

    }
    void FixedUpdate()
    {
       // Move();
    }

    void Move(){  
        transform.Translate(( 0.5f * tilesize * translationX ) + ( 0.5f * tilesize * translationY), ( -0.25f * tilesize * translationX ) + ( 0.25f * tilesize * translationY), 0);
    }
}
// transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);