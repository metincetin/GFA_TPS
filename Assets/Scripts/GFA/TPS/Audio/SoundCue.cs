using UnityEngine;

namespace GFA.TPS.Audio
{
    [CreateAssetMenu(menuName = "Audio/Sound Cue")]
    public class SoundCue : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] _audioClips;

        [SerializeField]
        private float _volume = 1;

        public AudioClip Get()
        {
            return _audioClips[Random.Range(0, _audioClips.Length)];
        }

        public void PlayOneShot(AudioSource source)
        {
            source.PlayOneShot(Get(), _volume);
        }
    }
}
