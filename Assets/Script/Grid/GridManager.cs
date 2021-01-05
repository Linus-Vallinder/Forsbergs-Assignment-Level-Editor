using Tiles;
using Tiles.UI;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;

        public GridGenerator GridGenerator => GetComponent<GridGenerator>();

        public TileTypeSelector TypeSelector => FindObjectOfType<TileTypeSelector>();

        public TileType[] TileTypes;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != null)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && TypeSelector.SelectedType != null)
            {
                ChangeTile();
            }
        }

        private void ChangeTile()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Tile>() && hit.collider.GetComponent<Tile>().Data.tileType != TypeSelector.SelectedType.TileID)
                {
                    hit.collider.GetComponent<Tile>().Data.tileType = TypeSelector.SelectedType.TileID;
                    hit.collider.GetComponent<Tile>().SetUp();
                }
            }
        }
    }

    [Serializable]
    class SaveData
    {
        public float GridX, GridY;

        public List<TileData> GridTiles = new List<TileData>();
    }
}
