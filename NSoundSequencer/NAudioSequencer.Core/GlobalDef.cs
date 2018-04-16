using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSequencer.Core
{
    public static class GlobalDef
    {
        public static WaveFormat WaveFormat => (WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, Channels));
        public static int BitsPerSecond => ((SampleRate * BitDepth) * Channels);
        public static int SampleRate = 44100;
        public static int BitDepth = 32; // IEEE Float.
        public static int BPM = 30;
        public static int Channels = 1;
      
    }
}
