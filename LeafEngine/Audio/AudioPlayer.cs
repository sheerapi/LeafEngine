using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SFML.Audio;

namespace Leaf
{
    public class AudioPlayer : Script
    {
        protected internal SoundBuffer buffer { get; set; }

        protected internal Sound sound { get; set; }

        public bool playAtStart { get; set; } = true;

        public float pitch { get; set; } = 1f;

        public bool loop { get; set; }

        public float duration { get; private set; }

        public float time { get; set; }

        public float volume { get; set; } = 1f;

        public string soundStatus { get; set; }

        public AudioPlayer(byte[] audio)
        {
            buffer = new SoundBuffer(audio);
            sound = new Sound(buffer);
        }

        public override void Start()
        {
            sound.SoundBuffer = buffer;

            if (playAtStart == true)
            {
                Play();
            }
        }

        public override void Update()
        {
            sound.Loop = loop;
            sound.Pitch = pitch;
            duration = buffer.Duration.AsSeconds();
            time = sound.PlayingOffset.AsSeconds();
            // sound.Volume = volume;

            switch (sound.Status)
            {
                case SoundStatus.Stopped:
                    soundStatus = "stopped";
                    break;
                case SoundStatus.Paused:
                    soundStatus = "paused";
                    break;
                case SoundStatus.Playing:
                    soundStatus = "playing";
                    break;
            }

            sound.Position = new SFML.System.Vector3f(transform.position.x, transform.position.y, transform.position.z);

            pitch += Input.GetAxis("Vertical", true) * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Vertical", true), transform.position.y + Input.GetAxis("Vertical", true), 0f);

            // Logger.Log(Input.GetAxis("Vertical", true) + " Pitch: " + pitch.ToString("0.00"), Logger.LogLevel.Trace);
        }

        public void Play() { sound.Play(); }

        public void Stop() { sound.Stop(); }

        public void Pause() { sound.Pause(); }
    }
}
