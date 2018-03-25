using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class StopCommand : ICommand
    {
        private WaveOut _waveOut;
        public StopCommand(WaveOut waveOut)
        {
            _waveOut = waveOut;
        }

        public void Execute()
        {
            _waveOut.Stop();
        }
    }
}
