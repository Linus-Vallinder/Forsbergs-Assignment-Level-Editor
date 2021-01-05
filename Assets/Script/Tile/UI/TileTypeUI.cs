using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Tiles.UI
{
    public class TileTypeUI : MonoBehaviour
    {
        public bool IsSelected;

        [Space]
        public TileType Type;

        [Space]
        public Text Name;

        public Image TilePreview;

        public GameObject SelectedOverlay;

        public UnityEvent<TileType, bool> OnSelected;

        private void Update()
        {
            if (IsSelected)
            {
                SelectedOverlay.SetActive(true);
            }
            else
            {
                SelectedOverlay.SetActive(false);
            }
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            Name.text = $"{Type.Name}";

            TilePreview.color = Type.Color;
        }

        public void ToggleSelect()
        {
            if (IsSelected)
            {
                IsSelected = false;
                OnSelected.Invoke(Type, false);
            }
            else if (!IsSelected)
            {
                IsSelected = true;
                OnSelected.Invoke(Type, true);
            }
        }
    }
}