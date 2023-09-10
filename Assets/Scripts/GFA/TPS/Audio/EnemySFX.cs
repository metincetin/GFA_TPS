using UnityEngine;

namespace GFA.TPS.Audio
{
    public class EnemySFX : MonoBehaviour
    {
        [SerializeField]
        private SoundCue _damageCue;
        [SerializeField]
        private SoundCue _attackCue;

        [SerializeField]
        private AudioSource _audioSource;

        public void PlayDamagedSFX()
        {
            _damageCue.PlayOneShot(_audioSource);
        }

        public void PlayAttackSFX()
        {
            _attackCue.PlayOneShot(_audioSource);
        }
    }
}
