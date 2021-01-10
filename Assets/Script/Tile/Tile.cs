using UnityEngine;
using Grid;

namespace Tiles
{
    public class Tile : MonoBehaviour
    {
        public TileData Data;

        private SpriteRenderer Renderer => GetComponent<SpriteRenderer>();

        public Tile(TileData tileData)
        {
            Data = tileData;
        }

        public void Start()
        {
            LoadColor();
        }

        public void LoadColor()
        {
            Renderer.color = GridManager.Instance.TileTypes[Data.tileType].Color;
        }
    }
}