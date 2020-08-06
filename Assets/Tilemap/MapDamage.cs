using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDamage : MonoBehaviour
{
    private Dictionary<Vector3Int, float> tiles = new Dictionary<Vector3Int, float>();
    private Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }
    
    public void DamageTile(float damage, Vector3Int tile) {
        if (tiles.ContainsKey(tile)) {
            tiles[tile] -= damage;
        } else {
            tiles.Add(tile, 100 - damage);
        }
        if (tiles[tile] <= 0) {
            DestroyTile(tile);
        }
    }

    void DestroyTile(Vector3Int tile) {
        tile = tilemap.WorldToCell(tile);
        tilemap.SetTile(Vector3Int.RoundToInt(tile), null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
