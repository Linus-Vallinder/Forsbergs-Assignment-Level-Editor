using UnityEngine;
using Grid;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Tiles.UI
{
    public class TileTypeSelector : MonoBehaviour
    {
        public TileType SelectedType
        {
            get
            {
                return selectedType;
            }

            set
            {
                selectedType = value;
                OnSelectedTypeChange.Invoke();
            }
        }

        private TileType selectedType;

        [Space]
        public GameObject UIElementPrefab;

        public UnityEvent OnSelectedTypeChange;

        public List<TileTypeUI> TileTypeUIs = new List<TileTypeUI>();

        private void Start()
        {
            CreateSelctorUI();

            ListnerSetup();
        }

        public void ListnerSetup()
        {
            foreach (var Type in TileTypeUIs)
            {
                Type.OnSelected.RemoveListener(ChangeSelected);
                Type.OnSelected.AddListener(ChangeSelected);
            }
        }

        private void ChangeSelected(TileType tileType, bool ChangeToTrue)
        {
            Debug.Log("Called Change Select for " + tileType);

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
                Debug.Log(SelectedType);
            }
            else if (!ChangeToTrue)
            {
                SelectedType = null;
            }
        }

        public void ReloadTypeUI()
        {
            foreach (var type in TileTypeUIs)
            {
                Destroy(type.gameObject);
            }

            TileTypeUIs.Clear();

            CreateSelctorUI();
        }

        private void CreateSelctorUI()
        {
            foreach (var types in GridManager.Instance.TileTypes)
            {
                var clone = Instantiate(UIElementPrefab, this.gameObject.transform);

                clone.GetComponent<TileTypeUI>().Type = types;
                TileTypeUIs.Add(clone.GetComponent<TileTypeUI>());
            }

            ListnerSetup();
        }
    }
}