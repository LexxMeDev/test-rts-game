using UnityEngine;

namespace TestGame.Interfaces
{
    public interface IInputProvider
    {
        Vector2 CameraMoveDelta { get; }
        bool IsCameraMoving { get; }
        bool TryGetMoveTarget(out Vector3 target);
    }
}