using TestGame.Interfaces;
using UnityEngine;

namespace TestGame.Controllers.Cameras
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Vector2 xBounds = new(-50, 50);
        [SerializeField] private Vector2 yBounds = new(-30, 30);

        public void Move(Vector2 delta)
        {
            Vector3 moveDelta = new Vector3(-delta.x, delta.y, 0) * moveSpeed;
            Vector3 newPosition = cameraTransform.position + moveDelta;

            newPosition.x = Mathf.Clamp(newPosition.x, xBounds.x, xBounds.y);
            newPosition.y = Mathf.Clamp(newPosition.y, yBounds.x, yBounds.y);

            cameraTransform.position = newPosition;
        }
    }
}