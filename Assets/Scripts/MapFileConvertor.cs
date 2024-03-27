using System.Collections;
using System.Collections.Generic;
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
    [Header("맵 정보")]
    public string mapName;
    public Vector2Int mapSize;
    public string spawnMonsterName;
    public string[] portalLinkNames;


    private void Reset()
    {
        mapName = gameObject.name;
        tilemap = GetComponent<Tilemap>();
        tileSetting = Resources.Load<TileSetting>("TileSetting");
        mapBorderColor = Color.red;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = mapBorderColor;
        Gizmos.DrawWireCube((Vector2)mapSize / 2, (Vector2)mapSize);
    }

    [ContextMenu("파일 생성")]
    public void GenerateFile()
    {
        string data = string.Format("");

        File.WriteAllText(tileSetting.outputPath + mapName + ".ini", data);
        AssetDatabase.Refresh();
    }

    [ContextMenu("디버그")]
    public void Test()
    {
        Debug.Log(tilemap.GetSprite(Vector3Int.zero));
    }
}
