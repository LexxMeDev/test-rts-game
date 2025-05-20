using TestGame.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestGame.Controllers.Inputs.Bases
{
    public abstract class BaseInputProvider : MonoBehaviour, IInputProvider
    {
        [Header("Layer Settings")]
        [SerializeField] protected LayerMask groundMask = 1 << 6;
        [SerializeField] protected LayerMask buildingMask = 1 << 7;

        [Header("UI Settings")]
        [SerializeField] private float _uiIgnoreRadius = 50f;

        public abstract Vector2 CameraMoveDelta { get; }
        public abstract bool IsCameraMoving { get; }

        public bool TryGetMoveTarget(out Vector3 target)
        {
            if (IsPointerOverUI())
            {
                target = Vector3.zero;
                return false;
            }

            if (TryGetClickPosition(out var position))
            {
                return TryGetBestTarget(position, out target);
            }

            target = Vector3.zero;
            return false;
        }

        protected abstract bool TryGetClickPosition(out Vector2 position);

        private bool TryGetBestTarget(Vector2 screenPosition, out Vector3 target)
        {
            var ray = UnityEngine.Camera.main.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out var buildingHit, Mathf.Infinity, buildingMask))
            {
                target = buildingHit.point;
                return true;
            }

            if (Physics.Raycast(ray, out var groundHit, Mathf.Infinity, groundMask))
            {
                target = groundHit.point;
                return true;
            }

            target = Vector3.zero;
            return false;
        }

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;

            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    return true;

                foreach (var result in GetRaycastResults(touch.position))
                {
                    if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
                        return true;
                }
            }

            return false;
        }

        private System.Collections.Generic.List<RaycastResult> GetRaycastResults(Vector2 screenPosition)
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = screenPosition
            };

            var results = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results;
        }
    }
}