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
            if (Input.GetMouseButton(0))
            {
                ChangeTile();
            }
        }

        private void ChangeTile()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Tile>())
                {
                    if (hit.collider.GetComponent<Tile>().Data.tileType != TypeSelector.SelectedType)
                    {
                        hit.collider.GetComponent<Tile>().Data.tileType = TypeSelector.SelectedType;
                        hit.collider.GetComponent<Tile>().SetUp();
                    }
                    else if (hit.collider.GetComponent<Tile>().Data.tileType = TypeSelector.SelectedType)
                    {
                        Debug.Log("Tile is of same type");
                    }
                }
            }
        }
    }
}