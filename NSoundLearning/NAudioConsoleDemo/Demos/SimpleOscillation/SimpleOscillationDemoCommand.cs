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
    class SimpleOscillationDemoCommand : ICommand
    {
        int sampleRate = 44100;
        int channels = 1;
        int frequency = 120;
        float gain = 0.25f;
        SignalGenerator signalGenerator;
        WasapiOut wasapiOut;
        CommandDirector cd;

        public SimpleOscillationDemoCommand()
        {
            wasapiOut = new WasapiOut();
            signalGenerator = new SignalGenerator(sampleRate, channels);
            signalGenerator.Frequency = frequency;
            signalGenerator.Gain = gain;

            wasapiOut.Init(signalGenerator);

            CommandRespiratory cr = new CommandRespiratory();
            cr.AddCommand("play", typeof(PlayCommand), (string[] param) => new PlayCommand(wasapiOut));
            cr.AddCommand("stop", typeof(StopCommand), (string[] param) => new StopCommand(wasapiOut));
            cr.AddCommand("setvolume", typeof(SetVolumeCommand), (string[] param) => new SetVolumeCommand(param, signalGenerator));
            cr.AddCommand("setfreq", typeof(SetFrequencyCommand), (string[] param) => new SetFrequencyCommand(param, signalGenerator));

            cd = new CommandDirector(cr);
            cd.Title = "Simple Oscillation";
        }

        public void Execute()
        {
            using (wasapiOut)
            {
                cd.Start();
            }
        }
    }
}
