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
    }
}