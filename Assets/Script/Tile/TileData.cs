using UnityEngine;

namespace Tiles
{
    [System.Serializable]
    public class TileData
    {
        public float PositionX, PositionY;

        public int tileType;

        public TileData(Vector2 tilePosition, int tileType)
        {
            PositionX = tilePosition.x;
            PositionY = tilePosition.y;

            this.tileType = tileType;
        }
    }
}