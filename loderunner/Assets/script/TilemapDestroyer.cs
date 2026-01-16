using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections; 

public class TilemapDestroyer : MonoBehaviour
{
    public Tilemap targetTilemap;

    public TileBase defaultTile;

    void Start()
    {
        if (targetTilemap == null)
        {
            Debug.LogError("Target Tilemap not set in the Inspector.");
        }
        if (defaultTile == null)
        {
            Debug.LogWarning("Default Tile not set! Tiles will not return after 5 seconds.");
        }
    }

    public void DestroyTileAt(Vector3 worldPosition)
    {
        if (targetTilemap == null || defaultTile == null) return;

        Vector3Int cellPosition = targetTilemap.WorldToCell(worldPosition);
        TileBase tile = targetTilemap.GetTile(cellPosition);

        if (tile != null)
        {
            
            targetTilemap.SetTile(cellPosition, null);
            Debug.Log($"Tile destroyed at cell position: {cellPosition}");

         
            StartCoroutine(RespawnTileAfterDelay(cellPosition, 5.0f));
        }
        else
        {
            Debug.Log($"No tile found at cell position: {cellPosition}");
        }
    }

    
    private IEnumerator RespawnTileAfterDelay(Vector3Int position, float delay)
    {
        
        yield return new WaitForSeconds(delay);

        
        if (targetTilemap.GetTile(position) == null)
        {
            targetTilemap.SetTile(position, defaultTile);
            Debug.Log($"Tile restored at cell position: {position}");
        }
    }
}