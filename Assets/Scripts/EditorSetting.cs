using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Editor Setting", menuName = "", order = int.MinValue)]
public class EditorSetting : ScriptableObject
{
    public List<string> outputPathList;
}
