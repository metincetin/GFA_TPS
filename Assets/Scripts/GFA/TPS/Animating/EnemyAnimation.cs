using UnityEngine;

namespace GFA.TPS.Animating
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        public void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeathAnimation()
        {
            _animator.SetBool(IsDead, true);
        }
    }
}
