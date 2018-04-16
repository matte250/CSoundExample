using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class HelloWorld : ICommand
    {

        public void Execute()
        {
            Console.WriteLine("Hello World!");
        }

    }
}
