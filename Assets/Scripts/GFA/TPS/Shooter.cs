using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFA.TPS
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float _fireRate = 0.5f;
        
        [SerializeField, Range(0, 1f)]
        private float _accuracy = 1f;

        [SerializeField]
        private float _recoil;

        [SerializeField]
        private float _recoilFade;

        private float _recoilValue = 0f;

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

            var rand = Random.value;
            var maxAngle = 30 - 30 * Mathf.Max(_accuracy - _recoilValue, 0);
            
            var randomAngle = Mathf.Lerp(-maxAngle, maxAngle,  rand);

            var forward = inst.transform.forward;
            
            forward = Quaternion.Euler(0, randomAngle, 0) * forward;

            inst.transform.forward = forward;

            _lastShootTime = Time.time;
            
            _recoilValue += _recoil;
        }

        private void Update()
        {
            _recoilValue = Mathf.MoveTowards(_recoilValue, 0, _recoilFade * Time.deltaTime);
        }
    }
}