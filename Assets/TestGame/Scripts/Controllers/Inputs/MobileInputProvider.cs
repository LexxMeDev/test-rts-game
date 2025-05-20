using TestGame.Controllers.Inputs.Bases;
using UnityEngine;

namespace TestGame.Controllers.Inputs
{
    public class MobileInputProvider : BaseInputProvider
    {
        [SerializeField] private float moveSpeed = 0.01f;
        
        private int _moveFingerId = -1;

        public override Vector2 CameraMoveDelta => GetCameraMoveDelta();
        public override bool IsCameraMoving => _moveFingerId != -1;

        protected override bool TryGetClickPosition(out Vector2 position)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began && touch.fingerId != _moveFingerId)
                {
                    position = touch.position;
                    return true;
                }
            }
            position = Vector2.zero;
            return false;
        }

        private Vector2 GetCameraMoveDelta()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved && touch.fingerId == _moveFingerId)
                {
                    return touch.deltaPosition * moveSpeed;
                }
            }
            return Vector2.zero;
        }

        private void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began && _moveFingerId == -1)
                {
                    _moveFingerId = touch.fingerId;
                }
                else if (touch.phase == TouchPhase.Ended && touch.fingerId == _moveFingerId)
                {
                    _moveFingerId = -1;
                }
            }
        }
    }
}