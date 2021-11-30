using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    Tilemap tilemap;
    PlayerState state;
    private Camera cam;
    public GameObject selectorTile;
    TileBase[] allTiles;
    BoundsInt bounds;
    TileBase[,] tiles;

    void Start()
    {
        
        cam = Camera.main;
        Tilemap tilemap = GameObject.Find("Colliders").GetComponent<Tilemap>();

        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);
        tiles = new TileBase[bounds.size.x,bounds.size.y];
        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                tiles[x,y] = tile;
                if (tile != null) {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                } else {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 point = GetCorrectedMousetoWorldPos();
        selectorTile.transform.position = point;
        int y = (int) Mathf.Floor(tiles.GetLength(1)/2 + point.y);
        int x = (int) Mathf.Floor(tiles.GetLength(0)/2 + point.x);
        Debug.Log(tiles.GetLength(1)/2 + point.y);
        Debug.Log(x + " | " + y);

         if(tiles[x,y].name == "Full_Wall"){
             Debug.Log("This is a  wall");
         }
        
    }

    private Vector3 GetMousetoWorldPos(){
        
        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

        return point;
    }

    private Vector3 GetCorrectedMousetoWorldPos(){
        var point = GetMousetoWorldPos();
        return new Vector3(Mathf.Floor(point.x) +0.5f, Mathf.Floor(point.y) +  0.5f, 0);
    }
}

public enum PlayerState {
    Wait,
    Interact,
    TileSelect
}
