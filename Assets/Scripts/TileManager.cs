using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<MapFileConvertor> ignore;

    [ContextMenu("�ϰ� ��ȯ")]
    public void ConvertAllMap()
    {
        MapFileConvertor[] maps = GetComponentsInChildren<MapFileConvertor>(true);
        foreach(MapFileConvertor map in maps)
        {
            if (!ignore.Contains(map))
            {
                map.GenerateFile();
            }
        }
    }
}
