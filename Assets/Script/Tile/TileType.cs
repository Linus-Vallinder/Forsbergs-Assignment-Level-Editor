using UnityEngine;

namespace Tile
{
    [System.Serializable]
    public class TileType
    {
        [Header("Tile Information")]
        public string Name;

        [Space]
        public Color Color;

        public Sprite Sprite;
    }
}