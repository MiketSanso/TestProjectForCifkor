using UnityEngine;

namespace _Project.Scripts.Common.MusicService
{
    public class MusicService
    {
        private AudioSource _audioSource;

        public MusicService(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}