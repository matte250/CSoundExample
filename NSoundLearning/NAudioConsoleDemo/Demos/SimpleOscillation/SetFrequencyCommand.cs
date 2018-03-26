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
    class SetFrequencyCommand : ICommand
    {
        private SignalGenerator signalGenerator;
        private int frequencyParam;
        public SetFrequencyCommand(string[] args, SignalGenerator signalGenerator)
        {
            this.signalGenerator = signalGenerator;
            // Try statement to see if frequency paramater is between inclusive 20 and 20000;
            try
            {
                if (args.Count() > 0)
                {
                    frequencyParam = Int32.Parse(args[0]);
                    if (frequencyParam > 20000 || frequencyParam < 20) throw new FormatException("Parameter should be between 20 and 20000");
                }
            }
            catch (FormatException e)
            {
                throw new CommandException("Invalid parameter.", e);
            }
        }

        public void Execute()
        {
            signalGenerator.Frequency = frequencyParam;
        }
    }
}

