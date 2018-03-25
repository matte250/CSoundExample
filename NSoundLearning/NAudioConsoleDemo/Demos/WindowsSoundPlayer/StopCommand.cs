using CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.WindowsSoundPlayer
{
    class StopCommand : ICommand
    {
        private SoundPlayer _soundPlayer;
        public StopCommand(SoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        public void Execute()
        {
            _soundPlayer.Stop();
        }
    }
}
