using System.Collections;
using System.Collections.Generic;
using GFA.TPS.WeaponSystem;
using UnityEngine;
using UnityEngine.Serialization;


namespace GFA.TPS
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _weapon;
        
        private float _recoilValue = 0f;

        private float _lastShootTime;
        public bool CanShoot => Time.time > _lastShootTime + _weapon.FireRate;
        
        [SerializeField]
        private GameObject _defaultProjectilePrefab;
        
        private WeaponGraphics _activeWeaponGraphics;

        [SerializeField]
        private Transform _weaponContainer;


        private void Start()
        {
            if (_weapon) CreateGraphics();
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (_activeWeaponGraphics)
            {
                ClearGraphics();
            }
            _weapon = weapon;

            if (!weapon)
            {
                CreateGraphics();
            }
        }

        private void CreateGraphics()
        {
            if (!_weapon) return;
            var instance = Instantiate(_weapon.WeaponGraphics, _weaponContainer);
            instance.transform.localPosition = Vector3.zero;
            _activeWeaponGraphics = instance;
        }

        private void ClearGraphics()
        {
            if (!_activeWeaponGraphics) return;
            Destroy(_activeWeaponGraphics.gameObject);
            _activeWeaponGraphics = null;
        }
        

        public void Shoot()
        {
            if (!_weapon) return;
            if (!CanShoot) return;


            var projectileToInstantiate = _defaultProjectilePrefab;
            
            if (_weapon.ProjectilePrefab)
            {
                projectileToInstantiate = _weapon.ProjectilePrefab;
            }

            var inst = Instantiate(projectileToInstantiate, _activeWeaponGraphics.ShootTransform.position, _activeWeaponGraphics.ShootTransform.rotation);

            var rand = Random.value;
            var maxAngle = 30 - 30 * Mathf.Max(_weapon.Accuracy - _recoilValue, 0);
            
            var randomAngle = Mathf.Lerp(-maxAngle, maxAngle,  rand);

            var forward = inst.transform.forward;
            
            forward = Quaternion.Euler(0, randomAngle, 0) * forward;

            inst.transform.forward = forward;

            _lastShootTime = Time.time;
            
            _recoilValue += _weapon.Recoil;
        }

        private void Update()
        {
            if (!_weapon) return;
            _recoilValue = Mathf.MoveTowards(_recoilValue, 0, _weapon.RecoilFade * Time.deltaTime);
        }
    }
}