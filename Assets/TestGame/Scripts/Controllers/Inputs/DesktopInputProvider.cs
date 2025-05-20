using TestGame.Controllers.Inputs.Bases;
using UnityEngine;

namespace TestGame.Controllers.Inputs
{
    public class DesktopInputProvider : BaseInputProvider
    {
        [SerializeField] private float moveSpeed = 0.05f;

        public override Vector2 CameraMoveDelta =>
            Input.GetMouseButton(1) ? new Vector2(
                Input.GetAxis("Mouse X") * moveSpeed,
                Input.GetAxis("Mouse Y") * moveSpeed
            ) : Vector2.zero;

        public override bool IsCameraMoving => Input.GetMouseButton(1);

        protected override bool TryGetClickPosition(out Vector2 position)
        {
            if (Input.GetMouseButton(1))
            {
                position = Vector2.zero;
                return false;
            }

            position = Input.mousePosition;
            return Input.GetMouseButtonDown(0);
        }
    }
}