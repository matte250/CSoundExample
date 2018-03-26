using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class SetVolumeCommand : ICommand
    {
        private WaveOut _waveOut;
        private float volumeParam;
        public SetVolumeCommand(string[] args, WaveOut waveOut)
        {
            _waveOut = waveOut;
            // Try statement to see if volume paramater is between inclusive 0.0 and 1.0;
            try
            {
                if (args.Count() > 0)
                {
                    volumeParam = float.Parse(args[0]);
                    if (volumeParam > 1.0 || volumeParam < 0.0) throw new FormatException("Parameter should be between 0.0 and 1.0");
                }
            }
            catch (FormatException e)
            {
                throw new CommandException("Invalid parameter.", e);
            }
        }

        public void Execute()
        {
            _waveOut.Volume = volumeParam;
        }
    }
}
