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

    void Start()
    {
        Tilemap tilemap = GameObject.Find("Colliders").GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
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
        // if(allTiles[Mathf.Floor(point.x)][])
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
