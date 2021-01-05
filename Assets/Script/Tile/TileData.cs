using UnityEngine;

namespace Tiles
{
    [System.Serializable]
    public class TileData
    {
        public Vector2 TilePosition;

        public int tileType;

        public TileData(Vector2 tilePosition, int tileType)
        {
            TilePosition = tilePosition;
            this.tileType = tileType;
        }
    }
}