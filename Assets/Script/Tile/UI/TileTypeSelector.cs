using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles.UI
{
    public class TileTypeSelector : MonoBehaviour
    {
        public TileType SelectedType;

        public TileTypeUI[] TileTypeUIs;

        private void Start()
        {
            TileTypeUIs = FindObjectsOfType<TileTypeUI>();
        }
    }
}