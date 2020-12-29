using UnityEngine;

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

        private void OnValidate()
        {
            Renderer.color = Data.tileType.Color;
        }
    }
}