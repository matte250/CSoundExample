using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSequencer.Core
{
    class NodeSampleGenerator
    {
        SequencerNode node;

        public NodeSampleGenerator(SequencerNode node)
        {
            SignalGenerator signal = new SignalGenerator(GlobalDef.SampleRate, GlobalDef.Channels);
        }
    }
}
