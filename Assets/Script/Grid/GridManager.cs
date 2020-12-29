using UnityEngine;
using Tiles;
using Tiles.UI;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;

        public GridGenerator GridGenerator => GetComponent<GridGenerator>();

        public TileTypeSelector TypeSelector => GetComponent<TileTypeSelector>();

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
    }
}