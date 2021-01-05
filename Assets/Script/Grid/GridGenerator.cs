using Tiles;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Grid
{
    public class GridGenerator : MonoBehaviour
    {
        [Header("Grid")]
        public List<Tile> GridTiles = new List<Tile>();

        [Header("Grid Generation Settings")]
        public TileType DefualtTileType;

        [Space]
        public GameObject tileObject;

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
                    CreateTile(tilePosition, DefualtTileType.TileID);
                }
            }
        }

        public void CreateTile(Vector2 tilePosition, int tileTypeID)
        {
            var clone = Instantiate(tileObject, new Vector3(tilePosition.x, tilePosition.y, 0), Quaternion.identity);

            clone.AddComponent<Tile>();

            clone.GetComponent<Tile>().Data = new TileData(tilePosition, tileTypeID);

            GridTiles.Add(clone.GetComponent<Tile>());
        }

        public List<TileData> GetGridData()
        {
            List<TileData> data = new List<TileData>();

            foreach (var tile in GridTiles)
            {
                data.Add(tile.Data);
            }

            return data;
        }

        public void Reset()
        {
            DestoryGrid();
            GenerateGrid();
        }

        public void DestoryGrid()
        {
            foreach (var tile in GridTiles)
            {
                Destroy(tile.gameObject);
            }

            GridTiles.Clear();
        }
    }
}