using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace GFA.TPS
{
    public class EnemyAttacker : MonoBehaviour, IDamageExecutor
    {
        [SerializeField]
        private float _damage;

        [SerializeField]
        private float _range;
        public float Range => _range;

        [SerializeField]
        private float _attackRate;

        private float _lastAttack;
        public bool CanAttack =>  Time.time > _lastAttack + _attackRate;
        
        public bool IsCurrentlyAttacking { get; private set; }

        public event Action<IDamageable> Attacked;

        private IDamageable _currentTarget;
        
        public void Attack(IDamageable target)
        {
            if (!CanAttack) return;
            _lastAttack = Time.time;
            Attacked?.Invoke(target);
            _currentTarget = target;
            IsCurrentlyAttacking = true;
        }

        public void ExecuteDamage()
        {
            if (_currentTarget == null) return;
            
            if (_currentTarget is MonoBehaviour mb)
            {
                if (Vector3.Distance(mb.transform.position, transform.position) < _range)
                {
                    _currentTarget.ApplyDamage(_damage);
                }
            }
            else
            {
                _currentTarget.ApplyDamage(_damage);
            }
            
            IsCurrentlyAttacking = false;
        }
    }
}
