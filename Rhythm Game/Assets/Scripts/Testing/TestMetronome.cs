using UnityEngine;
using RhythmGame.Components;
using RoboRyanTron.Unite2017.Variables;

namespace RhythmGame.Testing
{
    [RequireComponent(typeof(Metronome))]
    public class TestMetronome : MonoBehaviour
    {
        [SerializeField] private FloatVariable songBPM;
        [SerializeField] private FloatVariable lastBeat;

        private void Start() {
            Debug.Log("-= COUNTING METRONOME BEATS =-");
            Debug.Log($"Song BPM: {songBPM.Value}");
            Debug.Log("Counting in quarter notes");
        }

        public void OnBeatEvent() {
            Debug.Log((lastBeat.Value + 1) % 4);
        }
    }
}
