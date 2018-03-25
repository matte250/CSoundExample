using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class PlayCommand : ICommand
    {
        private WaveOut _waveOut;
        public PlayCommand(WaveOut waveOut)
        {
            _waveOut = waveOut;
        }

        public void Execute()
        {
            _waveOut.Play();
        }
    }
}
