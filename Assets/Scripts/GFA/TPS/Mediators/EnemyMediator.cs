using System;
using System.Collections;
using GFA.TPS.AI;
using GFA.TPS.Animating;
using GFA.TPS.Audio;
using UnityEngine;

namespace GFA.TPS.Mediators
{
    public class EnemyMediator : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float _health;

        private ItemDropper _itemDropper;

        private EnemyAttacker _attacker;
        private EnemyAnimation _enemyAnimation;

        private AIController _aiController;

        private EnemySFX _sfx;

        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
            _attacker = GetComponent<EnemyAttacker>();
            _enemyAnimation = GetComponent<EnemyAnimation>();
            _aiController = GetComponent<AIController>();
            _sfx = GetComponent<EnemySFX>();
        }

        private void OnEnable()
        {
            _attacker.Attacked += OnAttackerAttacked;
        }
        
        private void OnDisable()
        {
            _attacker.Attacked -= OnAttackerAttacked;
        }

        private void OnAttackerAttacked(IDamageable obj)
        {
            _enemyAnimation.PlayAttackAnimation();
            _sfx.PlayAttackSFX();
        }

        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;
            _sfx.PlayDamagedSFX();
            if (_health <= 0)
            {
                _enemyAnimation.PlayDeathAnimation();

                _aiController.enabled = false;
                
                StartCoroutine(DisableDelayed());
                
                if (_itemDropper)
                {
                    _itemDropper.OnDied();
                }
            }
        }

        private IEnumerator DisableDelayed()
        {
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}
