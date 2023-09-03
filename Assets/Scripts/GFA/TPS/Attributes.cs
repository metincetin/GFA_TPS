using UnityEngine;

namespace GFA.TPS
{
    [System.Serializable]
    public class Attributes
    {
        [SerializeField]
        private float _damage = 0;
        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }
        
        [SerializeField]
        private float _movementSpeed = 5;
        public float MovementSpeed
        {
            get => _movementSpeed;
            set => _movementSpeed = value;
        }
        
        [SerializeField]
        private float _attackSpeed = 1;
        public float AttackSpeed
        {
            get => _attackSpeed;
            set => _attackSpeed = value;
        }
        
        [SerializeField]
        private float _defence = 0;
        public float Defence
        {
            get => _defence;
            set => _defence = Mathf.Clamp(value, 0, 0.95f);
        }
    }
}
