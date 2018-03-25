using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoundLearning.Examples
{
    /// <summary>
    /// ClippingSampleProvider is an example of how to use SampleProvider.
    /// This class will take a ISampleProvider as a source, and return a Read buffer(sample) that
    /// will be clipped/brickwalled to values -1 and +1.
    /// </summary>
    class ClippingSampleProvider : ISampleProvider
    {
        /// <summary>
        /// Returns the source waveformat since we do not change the format of the sample in this case.
        /// </summary>
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }

        /// <summary>
        /// "source" is the variable that contains the ISampleProvider(sample) to be clipped
        /// </summary>
        private ISampleProvider source;

        /// <summary>
        /// Since we will use ClippingSampleProvider as an "effect", or in the middle of a signal chain,
        /// we will the source we want to change in ClippingSampleProvider's constructor.
        /// </summary>
        /// <param name="source">
        /// Sample to be clipped.
        /// </param>
        public ClippingSampleProvider(ISampleProvider source)
        {

            this.source = source;
        }

        /// <summary>
        /// Read will contain the modifed sample.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(float[] buffer, int offset, int count)
        {
            int sampleRead = source.Read(buffer, offset, count);
            for (int n = 0; n < sampleRead; n++)
            {
                if (buffer[offset + n] > 1.0f)
                    buffer[offset + n] = 1.0f;
                else if (buffer[offset + n] < -1.0f)
                    buffer[offset + n] = -1.0f;
            }
            return sampleRead;
        }
    }
}
