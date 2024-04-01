using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private static TileManager instance;
    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    public string outputPath;
    public List<MapFileConvertor> ignore;

    [ContextMenu("ÀÏ°ý º¯È¯")]
    public void ConvertAllMap()
    {
        MapFileConvertor[] maps = GetComponentsInChildren<MapFileConvertor>(true);
        foreach (MapFileConvertor map in maps)
        {
            if (!ignore.Contains(map))
            {
                map.GenerateFile();
            }
        }
    }

    public void SelectMap(MapFileConvertor selectedMap)
    {
        MapFileConvertor[] maps = GetComponentsInChildren<MapFileConvertor>(true);
        foreach (MapFileConvertor map in maps)
        {
            map.gameObject.SetActive(selectedMap == map);
        }
    }
}
