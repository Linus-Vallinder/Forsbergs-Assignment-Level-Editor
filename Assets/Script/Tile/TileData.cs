using UnityEngine;

namespace Tile
{
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