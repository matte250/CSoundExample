using CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.WindowsSoundPlayer
{
    class PlayCommand : ICommand
    {
        private SoundPlayer _soundPlayer;
        public PlayCommand(SoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        public void Execute()
        {
            _soundPlayer.Play();
        }
    }
}
