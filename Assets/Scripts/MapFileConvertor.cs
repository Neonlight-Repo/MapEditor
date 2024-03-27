using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapFileConvertor : MonoBehaviour
{
    [Header("에디터 정보")]
    public Tilemap tilemap;
    public TileSetting tileSetting;
    public Color mapBorderColor;
    public bool cutBorder;
    [Header("맵 정보")]
    public Vector2Int mapSize;
    public string spawnMonsterName;
    public MapFileConvertor[] portalLinks;

    private void Reset()
    {
        tilemap = GetComponent<Tilemap>();
        tileSetting = Resources.Load<TileSetting>("TileSetting");
        mapBorderColor = Color.red;
        cutBorder = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = mapBorderColor;
        Gizmos.DrawWireCube((Vector2)mapSize / 2, (Vector2)mapSize);

        if (cutBorder && tilemap != null)
        {
            CutTileMap();
        }
    }

    [ContextMenu("파일 생성")]
    public void GenerateFile()
    {
        string data = "[map]\nname=" + gameObject.name + "\nsize=" + mapSize.x + "," + mapSize.y + "\nportal=";
        if (portalLinks.Length > 0)
        {
            data += portalLinks[0];
            for (int i = 1; i < portalLinks.Length; i++)
            {
                data += "," + portalLinks[i].gameObject.name;
            }
        }
        data += "\nmonster=" + spawnMonsterName;
        data += "\n[data]\nmap=" + GetMapData();

        File.WriteAllText(tileSetting.outputPath + gameObject.name + ".ini", data);
        AssetDatabase.Refresh();
    }

    private string GetMapData()
    {
        string data = "";
        for (int y = mapSize.y - 1; y >= 0; y--)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                data += GetSpriteID(tilemap.GetSprite(new Vector3Int(x, y)));
            }
        }
        return data;
    }

    private int GetSpriteID(Sprite sprite)
    {
        if (sprite == tileSetting.wallSprite)
        {
            return 1;
        }
        else if (sprite == tileSetting.spawnPointSprite)
        {
            return 2;
        }
        else if (sprite == tileSetting.portalSprite)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    private void CutTileMap()
    {
        BoundsInt bounds = tilemap.cellBounds;
        tilemap.CompressBounds();

        tilemap.DeleteCells(new Vector3Int(0, 0), new Vector3Int(Mathf.Min(0, bounds.min.x), Mathf.Min(0, bounds.min.y)));
        tilemap.DeleteCells(new Vector3Int(mapSize.x, mapSize.y), new Vector3Int(Mathf.Max(0, bounds.max.x - mapSize.x), Mathf.Max(0, bounds.max.y - mapSize.y)));

        tilemap.CompressBounds();
    }
}
