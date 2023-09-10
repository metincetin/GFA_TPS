using GFA.TPS.Audio;
using UnityEngine;

namespace GFA.TPS.WeaponSystem.FX
{
    public class WeaponSFX : WeaponFX
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField] 
        private SoundCue _cue;
        
        protected override void OnShot()
        {
            _cue.PlayOneShot(_audioSource);
        }
    }
}
