using TestGame.Controllers.Cameras;
using TestGame.Controllers.Inputs;
using TestGame.Controllers.Player;
using TestGame.Interfaces;
using UnityEngine;

namespace TestGame.Controllers.Game
{
    public class GameController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private CharacterMovement character;
        [SerializeField] private CameraController camera;

        private IInputProvider _inputProvider;
        private bool _isInitialized;

        private void Awake()
        {
            InitializeInputProvider();
        }

        private void InitializeInputProvider()
        {
#if UNITY_ANDROID || UNITY_IOS
            _inputProvider = gameObject.AddComponent<MobileInputProvider>();
#else
            _inputProvider = gameObject.AddComponent<DesktopInputProvider>();
#endif

            _isInitialized = character != null && camera != null && _inputProvider != null;
        }

        private void Update()
        {
            if (!_isInitialized) return;

            HandleCameraMovement();
            HandleMovementInput();
        }

        private void HandleCameraMovement()
        {
            if (_inputProvider.IsCameraMoving)
            {
                camera.Move(_inputProvider.CameraMoveDelta);
            }
        }

        private void HandleMovementInput()
        {
            if (_inputProvider.IsCameraMoving) return;

            if (_inputProvider.TryGetMoveTarget(out var target))
            {
                character.MoveTo(target);
            }
        }
    }
}