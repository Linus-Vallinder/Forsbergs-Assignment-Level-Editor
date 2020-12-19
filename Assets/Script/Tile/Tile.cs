using UnityEngine;

namespace Tiles
{
    public class Tile : MonoBehaviour
    {
        public TileData Data;

        public Tile(TileData tileData)
        {
            Data = tileData;
        }
    }
}