using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NAudioSequencer.Core
{
    public class PlaybackEngine
    {
        private WasapiOut wasapiOut;
        private MixingSampleProvider mainMixer;
        private VolumeSampleProvider mainVolume;
        private Sequencer[] _sequencers;
        public Timer timer = new Timer(60000 / GlobalDef.BPM)
        {
            AutoReset = true,
            Enabled = false
        };

        public float Gain
        {
            get
            {
                return mainVolume.Volume;
            }
            set
            {
                mainVolume.Volume = value;
            }
        }

        public int CurrentStep { get; set; }
        private int endStep = 16;
        /// <summary>
        /// Creates a PlaybackEngine object with 3 Sequencers.
        /// </summary>
        public PlaybackEngine()
        {
            CurrentStep = 0;
            timer.Elapsed += (a, b) => PlayNode();
            mainMixer = new MixingSampleProvider(GlobalDef.WaveFormat);
            mainMixer.ReadFully = true;
            mainVolume = new VolumeSampleProvider(mainMixer);
            _sequencers = new Sequencer[3];
            for (int i = 0; i < _sequencers.Length; i++)
            {
                _sequencers[i] = new Sequencer();
            }
        }

        /// <summary>
        /// Get a node in a specific sequencer.
        /// </summary>
        /// <param name="x">Sequencer index</param>
        /// <param name="y">Node index</param>
        /// <returns>Node</returns>
        public SequencerNode GetNodeInSequencer(int x, int y)
        {
            return _sequencers[x].GetSequencerNode(y);
        }

        public Sequencer GetSequencer(int x)
        {
            return _sequencers[x];
        }

        public void Start()
        {
            wasapiOut = new WasapiOut();
            wasapiOut.Init(mainVolume);
            wasapiOut.Play();
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            wasapiOut.Dispose();
        }
        public void TimerRecalc()
        {
            timer.Interval = 6000 / GlobalDef.BPM;
        }

        public void PlayNode()
        {
            if (CurrentStep == endStep) CurrentStep = 0;
            // Loop thru each sequencer and play the node at the current step.
            for (int i = 0; i < _sequencers.Count(); i++)
            {
                if (_sequencers[i].Active == true && _sequencers[i].GetSequencerNode(CurrentStep).Active == true) // Check if sequencer or node is active.
                {
                    AdsrSampleProvider sample = _sequencers[i].GenerateSampleProvider(CurrentStep);
                    mainMixer.AddMixerInput(sample);
                    Timer timer2 = new Timer(_sequencers[i].sequencerNode[CurrentStep].GateTime)
                    {
                        AutoReset = false,
                        Enabled = true
                    };
                    timer2.Elapsed += (a, b) =>
                    {
                        StopNode(sample);
                        timer2.Dispose();
                    };
                }
            }         

            CurrentStep++;
        }

        public void StopNode(AdsrSampleProvider sample)
        {
            sample.Stop();
            //mainMixer.RemoveMixerInput(sample);
        }


        public void Dispose()
        {
            timer.Dispose();
            if(!wasapiOut.Equals(null)) wasapiOut.Dispose();
        }

    }
}
