using NAudioSequencer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoundSequencerForms
{
    public partial class MainForm : Form
    {
        private bool isPlaying = false;
        private TestPlaybackEngine test;
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.CloseForm);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseForm(Object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if(isPlaying == false)
            {
                isPlaying = true;
                test = new TestPlaybackEngine();
                test.Start();
            }

        }

        private void StopButton_Click(object sender, EventArgs e)
        {

            if (isPlaying == true)
            {
                isPlaying = false;
                test.Stop();
                test.Dispose();
            }

        }
    }
}
