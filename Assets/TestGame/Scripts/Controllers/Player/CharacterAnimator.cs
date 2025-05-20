using UnityEngine;
using UnityEngine.AI;

namespace TestGame.Controllers.Player
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float movementThreshold = 0.1f;

        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();
        private void Update() => UpdateAnimations();

        private void UpdateAnimations()
        {
            bool isMoving = agent.velocity.magnitude > movementThreshold;
            _animator.SetBool(IsRunning, isMoving);
        }
    }
}