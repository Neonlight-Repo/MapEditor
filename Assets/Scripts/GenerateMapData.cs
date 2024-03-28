using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateMapData : MonoBehaviour
{
    [MenuItem("Tools/Generate")]
    static void Generate()
    {
        RemoveAll(TileManager.Instance.outputPath);
        var maps = GameObject.Find("Map Grid").transform;
        foreach (Transform map in maps)
        {
            map.GetComponent<MapFileConvertor>().GenerateFile();
        }
        CopyTo(TileManager.Instance.outputPath, "../GameServer/MMOServer/common/generated/maps");
    }

    static void RemoveAll(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        FileInfo[] files = di.GetFiles();
        foreach (FileInfo file in files)
        {
            file.Delete();
        }
    }

    static void RemoveAll(string path, string str)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        FileInfo[] files = di.GetFiles();
        foreach (FileInfo file in files)
        {
            if (file.Name.Contains(str))
                file.Delete();
        }
    }

    static void CopyTo(string source, string destination)
    {
        if (Directory.Exists(destination))
            RemoveAll(destination, ".ini");
        else Directory.CreateDirectory(destination);

        var files = Directory.GetFiles(source);
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            if(!name.Contains(".meta"))
            {
                var dest = Path.Combine(destination, name);
                File.Copy(file, dest);
            }
        }
    }
}
