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
        private Mp3FileReader _reader;

        public NAudioPlaybackDemoCommand()
        {
            _waveOut = new WaveOut();
            _reader = new Mp3FileReader(GlobalDef.Mp3Url);
            _waveOut.Init(_reader);
        }

        public void Execute()
        {
            using (_reader)
            using (_waveOut)
            {

                CommandRespiratory cr = new CommandRespiratory();
                cr.AddCommand("play", typeof(PlayCommand), (string[] param) => new PlayCommand(_waveOut));
                cr.AddCommand("stop", typeof(StopCommand), (string[] param) => new StopCommand(_waveOut));
                cr.AddCommand("forward", typeof(ForwardCommand), (string[] param) => new ForwardCommand(_reader));
                cr.AddCommand("reverse", typeof(ReverseCommand), (string[] param) => new ReverseCommand(_reader));

                CommandDirector cd = new CommandDirector(cr);
                cd.Title = "NAudio Playback";
                cd.Start();
            }
        }

    }
}
