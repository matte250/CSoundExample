using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern;
using NAudioConsoleDemo.Demos.NAudioPlayback;
using NAudioConsoleDemo.Demos.WindowsSoundPlayer;

namespace NAudioConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting up commands.
            CommandRespiratory mainCommandRespiratory = new CommandRespiratory();

            mainCommandRespiratory.AddCommand(
                "windowssoundplayer",
                typeof(WindowsSoundPlayerDemoCommand),
                (string[] param) => new WindowsSoundPlayerDemoCommand());
            mainCommandRespiratory.AddCommand(
                "naudioplayback",
                typeof(NAudioPlaybackDemoCommand),
                (string[] param) => new NAudioPlaybackDemoCommand());

            CommandDirector mainCommandDirector = new CommandDirector(mainCommandRespiratory);
            mainCommandDirector.Title = "NAudio Demos";
            mainCommandDirector.Start();
        }
    }
}
