using UnityEngine;
using Grid;

namespace Tiles
{
    public class Tile : MonoBehaviour
    {
        public TileData Data;

        public SpriteRenderer Renderer => GetComponent<SpriteRenderer>();

        public Tile(TileData tileData)
        {
            Data = tileData;
        }

        public void SetUp()
        {
            Renderer.color = GridManager.Instance.TileTypes[Data.tileType].Color;
        }
    }
}