using NAudioSequencer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NSoundSequencer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Commandpattern setup

            // Temp
            string s = "6t0";
            int i = Int32.Parse(s.Substring(0, Char.IsNumber(s[1]) == true ? 2 : 1)) - 1;
            Console.WriteLine(i);
            TestPlaybackEngine test = new TestPlaybackEngine();
            using (test)
            {
                test.Start();
                Console.ReadLine();
                test.Stop();
            }
        }
    }
}
