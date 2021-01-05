using UnityEngine;
using Grid;

namespace Tiles.UI
{
    public class TileTypeSelector : MonoBehaviour
    {
        public TileType SelectedType;

        [Space]
        public GameObject UIElementPrefab;

        private TileTypeUI[] TileTypeUIs;

        private void Start()
        {
            CreateSelctorUI();

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

        private void CreateSelctorUI()
        {
            foreach (var types in GridManager.Instance.TileTypes)
            {
                var clone = Instantiate(UIElementPrefab, this.gameObject.transform);

                clone.GetComponent<TileTypeUI>().Type = types;
            }
        }
    }
}