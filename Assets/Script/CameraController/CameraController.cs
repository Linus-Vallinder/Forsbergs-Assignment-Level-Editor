using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        public Camera MainCamera;

        [Header("WASD Movement Settings")]
        public float MovementSpeed;

        [Header("Zoom Settings")]
        public float ZoomDefaultDistance = 10f;

        [Space]
        public float ZoomDistanceMin;

        [Space]
        public float ZoomSpeed = 5f;

        private void Start()
        {
            MainCamera.orthographicSize = ZoomDefaultDistance;
        }

        private void Update()
        {
            UpdateOrthographicZoom();

            UpdateWASDMovement();
        }

        private void UpdateWASDMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            MainCamera.transform.position += new Vector3(horizontal * MovementSpeed, vertical * MovementSpeed, 0) * Time.deltaTime;
        }

        private void UpdateOrthographicZoom()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (MainCamera.orthographicSize <= ZoomDistanceMin && scrollInput > 0)
            {
                return;
            }

            MainCamera.orthographicSize -= scrollInput * ZoomSpeed;
        }
    }
}