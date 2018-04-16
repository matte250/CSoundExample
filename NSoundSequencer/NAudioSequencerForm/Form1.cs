using NAudio.Wave.SampleProviders;
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

namespace NAudioSequencerForm
{
    public partial class Form1 : Form
    {

        PlaybackEngine pEngine;
        private bool isPlaying = false;

        public Form1()
        {
            InitializeComponent();
            pEngine = new PlaybackEngine();
        }

        /// <summary>
        /// Method that runs when the form is fully loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Setting up timer.
            System.Timers.Timer timer = pEngine.timer;
            //timer.Elapsed += (a, b) => RadioProgress();
            // Setting up Comboboxes default value.
            os1.SelectedIndex = 0;
            os2.SelectedIndex = 1;
            os3.SelectedIndex = 2;
        }

        private void MasterOsc_ValueChanged(object sender, EventArgs e)
        {
            ComboBox o = (ComboBox)sender;
            Sequencer seq = pEngine.GetSequencer(FormNameFormating.GetPanelIndex(o));

            switch (o.GetItemText(o.SelectedItem))
            {
                case "Sinus":
                    seq.SignalGeneratorType = SignalGeneratorType.Sin;
                    break;
                case "Saw":
                    seq.SignalGeneratorType = SignalGeneratorType.SawTooth;
                    break;
                case "Square":
                    seq.SignalGeneratorType = SignalGeneratorType.Square;
                    break;
                case "Noise":
                    seq.SignalGeneratorType = SignalGeneratorType.White;
                    break;
                default:
                    seq.SignalGeneratorType = SignalGeneratorType.Sin;
                    break;
            }
        }

        private void MasterGain_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            Sequencer seq = pEngine.GetSequencer(FormNameFormating.GetPanelIndex(o));
            seq.Gain = (float)o.Value;

        }

        private void MasterAttack_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            Sequencer seq = pEngine.GetSequencer(FormNameFormating.GetPanelIndex(o));
            seq.Attack = (int)o.Value;
        }

        private void MasterRelease_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            Sequencer seq = pEngine.GetSequencer(FormNameFormating.GetPanelIndex(o));
            seq.Release = (int)o.Value;
        }


        private void MasterActive_CheckChanged(object sender, EventArgs e)
        {
            CheckBox o = (CheckBox)sender;
            Sequencer seq = pEngine.GetSequencer(FormNameFormating.GetPanelIndex(o));
            seq.Active = o.Checked;
        }

        private void NodeTone_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            SequencerNode node = pEngine.GetNodeInSequencer(FormNameFormating.GetPanelIndex(o),FormNameFormating.GetNodeIndex(o));
            node.Note = (int)(48+o.Value);
        }

        private void NodeGain_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            SequencerNode node = pEngine.GetNodeInSequencer(FormNameFormating.GetPanelIndex(o), FormNameFormating.GetNodeIndex(o));
            node.Gain = (float)o.Value;
        }

        private void NodeGate_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown o = (NumericUpDown)sender;
            SequencerNode node = pEngine.GetNodeInSequencer(FormNameFormating.GetPanelIndex(o), FormNameFormating.GetNodeIndex(o));
            node.GateTime = (int)o.Value;
        }

        private void NodeActive_CheckChanged(object sender, EventArgs e)
        {
            CheckBox o = (CheckBox)sender;
            SequencerNode node = pEngine.GetNodeInSequencer(FormNameFormating.GetPanelIndex(o), FormNameFormating.GetNodeIndex(o));
            node.Active = o.Checked;
        }

        private void RadioButton_ButtonClicked(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            pEngine.Dispose();
            Application.Exit();
        }

        private void RadioProgress()
        {
            switch (pEngine.CurrentStep)
            {
                case 0:
                    n1rb.Checked = true;
                    break;
                case 1:
                    n2rb.Checked = true;
                    break;
                case 2:
                    n3rb.Checked = true;
                    break;
                case 3:
                    n4rb.Checked = true;
                    break;
                case 4:
                    n5rb.Checked = true;
                    break;
                case 5:
                    n6rb.Checked = true;
                    break;
                case 6:
                    n7rb.Checked = true;
                    break;
                case 7:
                    n8rb.Checked = true;
                    break;
                case 8:
                    n9rb.Checked = true;
                    break;
                case 9:
                    n10rb.Checked = true;
                    break;
                case 10:
                    n11rb.Checked = true;
                    break;
                case 11:
                    n12rb.Checked = true;
                    break;
                case 12:
                    n13rb.Checked = true;
                    break;
                case 13:
                    n14rb.Checked = true;
                    break;
                case 14:
                    n15rb.Checked = true;
                    break;
                case 15:
                    n16rb.Checked = true;
                    break;

            }
        }

        private void mPlayStop_Click(object sender, EventArgs e)
        {
            Button o = (Button)sender;
            if (!isPlaying)
            {
                isPlaying = true;
                pEngine.CurrentStep = 0;    
                pEngine.Start();
                o.Text = "Stop";
            }
            else
            {
                isPlaying = false;
                pEngine.Stop();
                o.Text = "Play";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GlobalDef.BPM = (int)numericUpDown1.Value;
            pEngine.TimerRecalc();
        }
    }
}
