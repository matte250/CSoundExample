using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    interface ICommandUndoable : ICommand
    {
        void Undo();
    }
}
