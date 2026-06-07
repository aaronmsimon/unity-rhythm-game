using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

namespace RhythmGame.Components
{
    [RequireComponent(typeof(AudioSource))]
    public class Metronome : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float errorMargin = 80f;

        [Header("Variables")]
        [SerializeField] private FloatVariable songBPM;
        [SerializeField] private FloatVariable musicTimePos;
        [SerializeField] private FloatVariable lastBeat;
        [SerializeField] private FloatVariable activeBeat;

        [Header("Game Events")]
        [SerializeField] private GameEvent beatEvent;

        private float beatDurationMS;
        private float nextBeatPos;
        private float activeBeatStartPos;
        private float activeBeatEndPos;

        private void Start() {
            beatDurationMS = 60 / songBPM.Value * 1000;
            lastBeat.Value = 0;
            nextBeatPos = beatDurationMS;
        }

        private void Update() {
            if (musicTimePos.Value >= nextBeatPos) {
                lastBeat.Value += 1;
                beatEvent.Raise();
                nextBeatPos += beatDurationMS;
                activeBeatStartPos = nextBeatPos - errorMargin;
                activeBeatEndPos = nextBeatPos + errorMargin;
            }
            if (musicTimePos.Value >= activeBeatStartPos && musicTimePos.Value <= activeBeatEndPos) {
            }
        }
    }
}
