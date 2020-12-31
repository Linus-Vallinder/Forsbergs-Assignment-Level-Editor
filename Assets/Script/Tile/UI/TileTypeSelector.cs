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
            ListnerSetup();
        }

        public void ListnerSetup()
        {
            foreach (var Type in TileTypeUIs)
            {
                Type.OnSelected.AddListener(ChangeSelected);
            }
        }

        private void ChangeSelected(TileType tileType, bool ChangeToTrue)
        {

            //TODO: Refactor this code
            if (ChangeToTrue)
            {
                foreach (var TypeUI in TileTypeUIs)
                {
                    if (TypeUI.IsSelected && TypeUI.Type != tileType)
                    {
                        TypeUI.IsSelected = false;
                    }
                }

                SelectedType = tileType;
            }
            else if (!ChangeToTrue)
            {
                SelectedType = null;
            }
        }
    }
}