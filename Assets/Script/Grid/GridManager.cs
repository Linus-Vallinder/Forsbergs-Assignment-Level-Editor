using System;
using System.Collections.Generic;
using Tiles;
using Tiles.UI;
using UnityEngine;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;

        public GridGenerator GridGenerator => GetComponent<GridGenerator>();

        public TileTypeSelector TypeSelector => FindObjectOfType<TileTypeSelector>();

        public List<TileType> TileTypes;

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
                    hit.collider.GetComponent<Tile>().LoadColor();
                }
            }
        }

        public List<Type> GetTypesData()
        {
            List<Type> types = new List<Type>();

            foreach (var type in TileTypes)
            {
                types.Add(new Type(type.Name, type.Color));
            }

            return types;
        }

        public void LoadTypes(List<Type> types)
        {
            TileTypes.Clear();

            for (int i = 0; i < types.Count; i++)
            {
                TileTypes.Add(new TileType(types[i].Name, i, new Color(types[i].r, types[i].g, types[i].b)));
            }

            TypeSelector.ReloadTypeUI();
        }
    }

    [Serializable]
    public class SaveData
    {
        public List<TileData> GridTiles = new List<TileData>();
        public List<Type> Types = new List<Type>();
    }

    [Serializable]
    public class Type
    {
        public string Name;
        public float r, g, b;

        public Type(string name, Color color)
        {
            Name = name;

            r = color.r;
            g = color.g;
            b = color.b;
        }
    }
}