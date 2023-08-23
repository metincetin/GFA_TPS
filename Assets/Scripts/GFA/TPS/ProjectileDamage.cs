using System;
using GFA.TPS.Movement;
using UnityEngine;

namespace GFA.TPS
{
    public class ProjectileDamage : MonoBehaviour
    {
        [SerializeField]
        private float _damage = 1;
        public float Damage
        {
            get => _damage;
            set
            {
                _damage = value;
            }
        }

        private ProjectileMovement _projectileMovement;

        private void Awake()
        {
            _projectileMovement = GetComponent<ProjectileMovement>();
        }

        private void OnEnable()
        {
            _projectileMovement.Impacted += OnImpacted;
        }
        private void OnDisable()
        {
            _projectileMovement.Impacted -= OnImpacted;
        }

        private void OnImpacted(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(_damage, gameObject);
            }
        }
    }
}
