using Tiles;
using UnityEngine;

namespace Grid
{
    public class GridGenerator : MonoBehaviour
    {
        [Header("Grid Generation Settings")]
        public TileType DefualtTileType;

        [Space]
        public GameObject DefualtTilePrefab;

        [Space]
        public Vector2 GridOrigin = Vector2.zero;

        [Space]
        public float GridSpacing = 1.0f;

        [Space]
        public int GridX = 10;

        public int GridY = 10;

        private void Start()
        {
            GenerateGrid();
        }

        public void GenerateGrid()
        {
            for (int x = 0; x < GridX; x++)
            {
                for (int y = 0; y < GridY; y++)
                {
                    Vector2 tilePosition = new Vector2(x * GridSpacing, y * GridSpacing) + (GridOrigin + new Vector2(-GridX * 0.45f, -GridY * 0.45f));
                    CreateTile(tilePosition, DefualtTileType);
                }
            }
        }

        public void CreateTile(Vector2 tilePosition, TileType tileType)
        {
            Instantiate(DefualtTilePrefab, new Vector3(tilePosition.x, tilePosition.y, 0), Quaternion.identity);
        }
    }
}