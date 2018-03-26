using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class ResetCommand : ICommand
    {
        private WaveStream _waveStream;

        public ResetCommand(WaveStream waveStream)
        {
            _waveStream = waveStream;
        }

        public void Execute()
        {
            _waveStream.CurrentTime = new TimeSpan(0);

        }
    }
}
