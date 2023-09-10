using UnityEngine;

namespace GFA.TPS.WeaponSystem.FX
{
    public class WeaponSFX : WeaponFX
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _audioClip;
        
        protected override void OnShot()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
