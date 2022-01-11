using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TimeToAction))]

public class Conveyor : MonoBehaviour
{
    public Vector3Int relativeDestination;

    BaseGrid baseGrid;
    Vector3Int sourcePosition;
    Vector3Int absoluteDestination;
    TileBase sourceTile;
    Transform sourceStack;
    TileBase destinationTile;
    Transform destinationStack;
    TimeToAction timeToAction;
    List<Transform> pucsToMove;

    // Conveyor gets items from floor grid and moves them to another.

    void Start()
    {
        // Attach action script
        timeToAction = transform.GetComponent<TimeToAction>();

        pucsToMove = new List<Transform>();

        baseGrid = transform.parent.GetComponentInParent<BaseGrid>();
        sourcePosition = baseGrid.machineryTilemap.WorldToCell(transform.position);
        absoluteDestination = sourcePosition + relativeDestination;

        try
        {
            sourceStack = baseGrid.floorTilemap.GetInstantiatedObject(sourcePosition).transform;
        }
        catch
        {
            Debug.Log($"Conveyor at ({sourcePosition.x},{sourcePosition.y}) has invalid source tile.");
        }

        try
        {
            destinationStack = baseGrid.floorTilemap.GetInstantiatedObject(absoluteDestination).transform;
        }
        catch
        {
            Debug.Log($"Conveyor at ({sourcePosition.x},{sourcePosition.y}) has invalid destination tile.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (destinationStack != null)
        {
            if (timeToAction.firing)
            {
                foreach (Transform child in pucsToMove)
                {
                    child.parent = destinationStack;
                }
            }
        }
        // List of all obj in previous step.
        pucsToMove.Clear();
        foreach (Transform child in sourceStack.transform)
        {
            pucsToMove.Add(child);
        }
        // Vector3Int tilePosition = tilemap.WorldToCell(dragGhost.transform.position);
        // //Tile.GetTileData(tilePosition, null, ref null);
        // //tile.GetTileData
        // //Tile.GetTileData(tilePosition, null, ref tempdata);
        // //transform.parent = tile.
        // try{
        //     // Tiles _objects_ should all be at 0 elevation. 
        //     Transform newStack = tilemap.GetInstantiatedObject(new Vector3Int(tilePosition.x,tilePosition.y,0)).transform;
        //     gameObject.transform.parent = newStack;
        //     gameObject.transform.localPosition = new Vector3(0,0,0);
        // }catch(NullReferenceException e){
        //     Debug.Log(e);
        // }
    }
}
