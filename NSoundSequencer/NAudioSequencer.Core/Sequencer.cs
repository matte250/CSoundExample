using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSequencer.Core
{
    public class Sequencer
    {
        public SequencerNode[] sequencerNode;
        private float _gain;
        private float _attack;
        private float _release;

        public SignalGeneratorType SignalGeneratorType { get; set; }

        public int Attack
        {
            get
            {
                return (int)_attack * 1000;
            }
            set
            {
                _attack = (float)value / 1000;
            }
        }

        public int Release
        {
            get
            {
                return (int)_release * 1000;
            }
            set
            {
                _release = (float)value / 1000;
            }
        }

        /// <summary>
        /// If sequencer should be played when called.
        /// </summary>
        public bool Active { get; set; }

        public float Gain
        {
            set
            {
                if (value < 0f) _gain = 0;
                else if (value > 1f) _gain = 1;
                else _gain = value;
            }
            get
            {
                return _gain;
            }
        }

        public SequencerNode GetSequencerNode(int i)
        {
            return sequencerNode[i];
        }

        /// <summary>
        /// Fills the sequencer with 16 secuencer nodes using default values.
        /// </summary>
        public Sequencer()
        {
            // Nodes setup
            sequencerNode = new SequencerNode[16];
            for (int i = 0; i < sequencerNode.Length; i++)
            {
                sequencerNode[i] = new SequencerNode();
            }
            // Properties setup
            Active = false;
            Attack = 0;
            Release = 0;
            SignalGeneratorType = SignalGeneratorType.Sin;
            Gain = 1f;

        }

        public void SetSequencerNode(SequencerNode node, int i)
        {
            sequencerNode[i] = node;
        }


        public AdsrSampleProvider GenerateSampleProvider(int i)
        {
            SequencerNode node = sequencerNode[i];
            SignalGenerator signal = new SignalGenerator(GlobalDef.SampleRate, GlobalDef.Channels);
            signal.Frequency = node.Frequency;
            signal.Gain = node.Gain * Gain;
            signal.Type = SignalGeneratorType;
            AdsrSampleProvider adsr = new AdsrSampleProvider(signal);
            adsr.AttackSeconds = _attack;
            adsr.ReleaseSeconds = _release;
            return adsr;
        }
    }
}
