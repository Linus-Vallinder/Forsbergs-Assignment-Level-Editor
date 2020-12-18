using UnityEngine;

namespace Tile
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