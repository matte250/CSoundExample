using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAudioSequencerForm
{
    public static class FormNameFormating
    {
        /// <summary>
        /// Returns the index-1 of a parent panel. Format of parent name should be "P" + Number. 
        /// </summary>
        /// <param name="control">The control to return a index for.</param>
        /// <returns></returns>
        public static int GetPanelIndex(Control control)
        {
            Panel panel = (Panel)control.Parent;
            return Int32.Parse(panel.Name.Replace("P", " ")) - 1;
        }

        /// <summary>
        /// Retrurns the index-1 of a control relative to a sequencer node. Format of name should be "n" + Number + %s.
        /// Can only contain 2 digits.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static int GetNodeIndex(Control control)
        {
            string s = control.Name.Replace("n","");
            return Int32.Parse(s.Substring(0, Char.IsNumber(s[1]) == true ? 2 : 1))-1;
        }
    }
}
