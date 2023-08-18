using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFA.TPS
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField]
        private float _fireRate = 0.5f;

        private float _lastShootTime;
        public bool CanShoot => Time.time > _lastShootTime + _fireRate;
        
        [SerializeField]
        private GameObject _projectilePrefab;
        
        [SerializeField]
        private Transform _shootTransform;
        

        public void Shoot()
        {
            if (!CanShoot) return;

            var inst = Instantiate(_projectilePrefab, _shootTransform.position, _shootTransform.rotation);
            
            

            _lastShootTime = Time.time;
        }
    }
}