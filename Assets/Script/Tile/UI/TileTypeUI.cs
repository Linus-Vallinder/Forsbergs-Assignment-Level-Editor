using UnityEngine;
using UnityEngine.UI;

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

        private void OnValidate()
        {
            Setup();
        }

        private void Setup()
        {
            Name.text = $"{Type.Name}";

            TilePreview.sprite = Type.Sprite;
            TilePreview.color = Type.Color;
        }

        public void ToggleSelect()
        {
            if (IsSelected)
            {
                IsSelected = false;
            }
            else if (!IsSelected)
            {
                IsSelected = true;
            }
        }
    }
}