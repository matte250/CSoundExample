using NAudio.Wave.SampleProviders;
using NSoundSequencer.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSequencer.Core
{
    public class SequencerNode
    {
        private float _gain;
        private float _frequency;
        private int _gateTime;

        /// <summary>
        /// Sets the status of this node.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Set gain of node to be between 0f and 1f.
        /// </summary>
        public float Gain {
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

        /// <summary>
        /// Sets the note index from 0 to 107 in MIDI notiation.
        /// </summary>
        public int Note
        {
            set
            {
                _frequency = FrequencyBank.GetFrequency(value);
            }
        }

        /// <summary>
        /// Sets the length of time a note should be played for in milliseconds. If ADSR is used, it will be the "hold" time.
        /// </summary>
        public int GateTime
        {
            get
            {
                return _gateTime;
            }
            set
            {
                if (value < 50) _gateTime = 50;
                else if (value > 1000) _gateTime = 1000;
                else _gateTime = value;
            }
        }

        public float Frequency => _frequency;

        public SequencerNode()
        {
            Gain = 0.5f;
            Note = 48;
            GateTime = 100;
            Active = false;

            //signal = new SignalGenerator(GlobalDef.SampleRate, GlobalDef.Channels);
        }


    }
}
