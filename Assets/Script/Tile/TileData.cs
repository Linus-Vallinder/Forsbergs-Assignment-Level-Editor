using UnityEngine;

namespace Tiles
{
    [System.Serializable]
    public class TileData
    {
        public Vector2 TilePosition;

        public TileType tileType;

        public TileData(Vector2 tilePosition, TileType tileType)
        {
            TilePosition = tilePosition;
            this.tileType = tileType;
        }
    }
}