using System;
using UnityEngine;

namespace GFA.TPS.WeaponSystem.FX
{
    public abstract class WeaponFX : MonoBehaviour
    {
        private WeaponGraphics _weaponGraphics;
        
        private void Awake()
        {
            _weaponGraphics = GetComponent<WeaponGraphics>();
        }

        private void OnEnable()
        {
            _weaponGraphics.Shot += OnShot;
        }

        private void OnDisable()
        {
            _weaponGraphics.Shot -= OnShot;
        }

        protected abstract void OnShot();
    }
}
