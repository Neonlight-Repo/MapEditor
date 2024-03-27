using UnityEngine;

[CreateAssetMenu(fileName = "TileSetting", menuName = "Create Tile Setting", order = int.MinValue)]
public class TileSetting : ScriptableObject
{
    public Sprite wallSprite;
    public Sprite spawnPointSprite;
    public Sprite portalSprite;
}
