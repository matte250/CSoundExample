using CommandPattern;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.SimpleOscillation
{
    class StopCommand : ICommand
    {

        IWavePlayer wavePlayer;

        public StopCommand(IWavePlayer wavePlayer)
        {
            this.wavePlayer = wavePlayer;
        }

        public void Execute()
        {
            wavePlayer.Stop();
        }
    }
}
