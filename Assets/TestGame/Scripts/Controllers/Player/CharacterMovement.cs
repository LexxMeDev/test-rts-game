using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace TestGame.Controllers.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Coroutine _movementCoroutine;

        private void Awake() => _agent = GetComponent<NavMeshAgent>();

        public void MoveTo(Vector3 target)
        {
            if (_movementCoroutine != null) StopCoroutine(_movementCoroutine);
            _movementCoroutine = StartCoroutine(MovementRoutine(target));
        }

        private IEnumerator MovementRoutine(Vector3 target)
        {
            _agent.SetDestination(target);
            yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
            _movementCoroutine = null;
        }
    }
}