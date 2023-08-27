using UnityEngine;

namespace GFA.TPS.Mediators
{
    public class EnemyMediator : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float _health;
        
        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;

            if (_health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
