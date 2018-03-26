using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class NAudioPlaybackDemoCommand : ICommand
    {
        private WaveOut _waveOut;
        private WaveStream _reader;
        private CommandDirector cd;

        public NAudioPlaybackDemoCommand()
        {
            _waveOut = new WaveOut();
            _reader = new AudioFileReader(GlobalDef.WavUrl);
            _waveOut.Init(_reader);

            // Setting up commands.
            CommandRespiratory cr = new CommandRespiratory();
            cr.AddCommand("play", typeof(PlayCommand), (string[] param) => new PlayCommand(_waveOut));
            cr.AddCommand("stop", typeof(StopCommand), (string[] param) => new StopCommand(_waveOut));
            cr.AddCommand("forward", typeof(ForwardCommand), (string[] param) => new ForwardCommand(_reader));
            cr.AddCommand("reverse", typeof(ReverseCommand), (string[] param) => new ReverseCommand(_reader));
            cr.AddCommand("reset", typeof(ResetCommand), (string[] param) => new ResetCommand(_reader));
            cr.AddCommand("getdevices", typeof(GetDevicesCommand), (string[] param) => new GetDevicesCommand());
            cr.AddCommand("setvolume", typeof(SetVolumeCommand), (string[] param) => new SetVolumeCommand(param, _waveOut));

            cd = new CommandDirector(cr);
            cd.Title = "NAudio Playback";
        }

        public void Execute()
        {
            using (_reader)
            using (_waveOut)
            {           
                cd.Start();
            }
        }

    }
}
