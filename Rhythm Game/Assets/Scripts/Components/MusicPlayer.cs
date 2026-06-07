using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace RhythmGame.Components
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private FloatVariable musicTimePos;

        private AudioSource audioSource;

        private void Awake() {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update() {
            if (audioSource.isPlaying) {
                musicTimePos.Value = (float)AudioSettings.dspTime;
            }
        }

        public void ChangeAndPlayTrack(AudioClip newTrack) {
            audioSource.Stop();
            audioSource.clip = newTrack;
            audioSource.Play();
        }
    }
}
