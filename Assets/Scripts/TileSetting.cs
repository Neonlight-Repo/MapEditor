using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileSetting", menuName = "Create Tile Setting", order = int.MinValue)]
public class TileSetting : ScriptableObject
{
    public string outputPath;
    public Sprite wallSprite;
    public Sprite spawnPointSprite;
    public Sprite portalSprite;
}
