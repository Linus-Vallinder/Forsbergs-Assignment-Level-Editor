using UnityEngine;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;

        public GridGenerator GridGenerator => GetComponent<GridGenerator>();

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