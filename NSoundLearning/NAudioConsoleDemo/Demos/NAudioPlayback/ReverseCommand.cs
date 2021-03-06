﻿using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class ReverseCommand : ICommand
    {
        private WaveStream _waveStream;

        public ReverseCommand(WaveStream waveStream)
        {
            _waveStream = waveStream;
        }

        public void Execute()
        {
            _waveStream.CurrentTime = _waveStream.CurrentTime.Add(new TimeSpan(0, 0, -10));
        }
    }
}
