using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu(fileName = "Type", menuName = "New TileType")]
    public class TileType : ScriptableObject
    {
        [Header("Tile Information")]
        public string Name;

        [Space]
        public int TileID;

        [Space]
        public Color Color;

        public TileType(string name, int id, Color color)
        {
            Name = name;
            TileID = id;
            Color = color;
        }
    }
}