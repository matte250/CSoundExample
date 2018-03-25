using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using CommandPattern;

namespace NAudioConsoleDemo.Demos.WindowsSoundPlayer
{
    class WindowsSoundPlayerDemoCommand : ICommand
    {
        SoundPlayer _soundPlayer;
        public WindowsSoundPlayerDemoCommand()
        {
            _soundPlayer = new SoundPlayer(); // Soundplayer is C# built in sound driver.
            _soundPlayer.SoundLocation = GlobalDef.WavUrl;
        }

        public void Execute()
        {
            // Using nested command patterns to simulate a console menu.
            CommandRespiratory cr = new CommandRespiratory();
            cr.AddCommand("play", typeof(PlayCommand),(string[] param) => new PlayCommand(_soundPlayer));
            cr.AddCommand("playlooping", typeof(PlayLoopingCommand), (string[] param) => new PlayLoopingCommand(_soundPlayer));
            cr.AddCommand("stop", typeof(StopCommand), (string[] param) => new StopCommand(_soundPlayer));

            CommandDirector cd = new CommandDirector(cr);     
            cd.Title = "Windows SoundPlayer";
            cd.Start();

            _soundPlayer.Stop();
        }
    }
}
