using CommandPattern;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioConsoleDemo.Demos.NAudioPlayback
{
    class GetDevicesCommand : ICommand
    {
        public GetDevicesCommand()
        {

        }

        public void Execute()
        {
            for (int i = 0; i < DirectSoundOut.Devices.Count(); i++)
            {
                Console.WriteLine("{0}. {1}", i, DirectSoundOut.Devices.ElementAt(i).Description);
            }
        }
    }
}
