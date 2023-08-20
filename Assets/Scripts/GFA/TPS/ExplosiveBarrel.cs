using UnityEngine;

namespace GFA.TPS
{
    public class ExplosiveBarrel : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float _health = 5;

        [SerializeField]
        private float _explosionRadius = 5;

        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            var hits = Physics.OverlapSphere(transform.position, _explosionRadius);
            Destroy(gameObject);
        }
    }
}
