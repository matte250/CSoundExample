using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NAudioSequencer.Core
{
    public class TestPlaybackEngine : IDisposable
    {
        private MixingSampleProvider mainMixer;
        private Sequencer sequencer;
        private Timer timer = new Timer(6000 / GlobalDef.BPM)
        {
            AutoReset = true,
            Enabled = false
        };
        private WasapiOut wasapiOut;

        private int currentStep;
        private int endStep = 16;

        public TestPlaybackEngine()
        {
            currentStep = 0;
            timer.Elapsed += (a, b) => PlayNode();
            mainMixer = new MixingSampleProvider(GlobalDef.WaveFormat);
            mainMixer.ReadFully = true;
            sequencer = new Sequencer();

            var temp1 = new SequencerNode();
            temp1.Note = 39;
            var temp2 = new SequencerNode();
            temp2.Note = 17;
            var temp3 = new SequencerNode();
            temp3.Note = 18;
            var temp4 = new SequencerNode();
            temp4.Note = 30;
            //
            var temp5 = new SequencerNode();
            temp5.Note = 39;
            var temp6 = new SequencerNode();
            temp6.Note = 17;
            var temp7 = new SequencerNode();
            temp7.Note = 18;
            var temp8 = new SequencerNode();
            temp8.Note = 30;
            //
            var temp9 = new SequencerNode();
            temp9.Note = 39;
            var temp10 = new SequencerNode();
            temp10.Note = 17;
            var temp11 = new SequencerNode();
            temp11.Note = 18;
            var temp12 = new SequencerNode();
            temp12.Note = 30;
            //
            var temp13 = new SequencerNode();
            temp13.Note = 17;
            var temp14 = new SequencerNode();
            temp14.Note = 17;
            var temp15 = new SequencerNode();
            temp15.Note = 18;
            var temp16 = new SequencerNode();
            temp16.Note = 30;

            sequencer.SetSequencerNode(temp1, 0);
            sequencer.SetSequencerNode(temp2, 1);
            sequencer.SetSequencerNode(temp3, 2);
            sequencer.SetSequencerNode(temp4, 3);
            sequencer.SetSequencerNode(temp5, 4);
            sequencer.SetSequencerNode(temp6, 5);
            sequencer.SetSequencerNode(temp7, 6);
            sequencer.SetSequencerNode(temp8, 7);
            sequencer.SetSequencerNode(temp9, 8);
            sequencer.SetSequencerNode(temp10, 9);
            sequencer.SetSequencerNode(temp11, 10);
            sequencer.SetSequencerNode(temp12, 11);
            sequencer.SetSequencerNode(temp13, 12);
            sequencer.SetSequencerNode(temp14, 13);
            sequencer.SetSequencerNode(temp15, 14);
            sequencer.SetSequencerNode(temp16, 15);
        }

        public void Start()
        {
            wasapiOut = new WasapiOut();
            wasapiOut.Init(mainMixer);
            wasapiOut.Play();
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            wasapiOut.Dispose();
        }

        public void PlayNode()
        {
            if (currentStep == endStep) currentStep = 0;

            AdsrSampleProvider sample = sequencer.GenerateSampleProvider(currentStep);
            mainMixer.AddMixerInput(sample);
            
            Timer timer2 = new Timer(sequencer.sequencerNode[currentStep].GateTime)
            {
                AutoReset = false,
                Enabled = true
            };
            timer2.Elapsed += (a, b) =>
            {
                StopNode(sample);
                timer2.Dispose();
            };

            currentStep++;
        }

        public void StopNode(AdsrSampleProvider sample)
        {
            sample.Stop();
            //mainMixer.RemoveMixerInput(sample);
        }
        
        public void TimerRecalc()
        {
            timer.Interval = 6000 / GlobalDef.BPM;
        }


        public void Dispose()
        {
            timer.Dispose();
            wasapiOut.Dispose();
        }


    }
}
