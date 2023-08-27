using GFA.TPS.MatchSystem;
using UnityEngine;

namespace GFA.TPS.Movement.Tests
{
    public class AIMovementTest : MonoBehaviour
    {
        [SerializeField]
        private float _acceptanceRadius;
        private CharacterMovement _characterMovement;

        [SerializeField]
        private MatchInstance _matchInstance;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            var distance = Vector3.Distance(transform.position, _matchInstance.Player.transform.position);

            if (distance > _acceptanceRadius)
            {
                var direction = (_matchInstance.Player.transform.position - transform.position).normalized;
                _characterMovement.MovementInput = new Vector2(direction.x, direction.z);
            }
        }

    }
}
