namespace CSharpBasic.TestCases
{
    internal sealed class FourierTransform : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "FourierTransform";

        public const double SampleRate = 1024.0;
        public const int SamplesCount = 1024;

        private readonly double[] m_Samples = new double[SamplesCount];
        private readonly double[] m_FourierRe = new double[SamplesCount];
        private readonly double[] m_FourierIm = new double[SamplesCount];

        protected override void PerformTask(Random random)
        {
            for(int i = 0; i < SamplesCount; ++i) {
                m_Samples[i] = 2.0 * random.NextDouble() - 1.0;
            }

            for(int i = 0; i < SamplesCount; ++i) {
                m_FourierRe[i] = 0.0;
                m_FourierIm[i] = 0.0;

                for(int j = 0; j < SamplesCount; ++j) {
                    m_FourierRe[i] += Math.Cos(2.0 * Math.PI * i * j / SampleRate) * m_Samples[j];
                    m_FourierIm[i] += Math.Sin(2.0 * Math.PI * i * j / SampleRate) * m_Samples[j];
                }

                m_FourierRe[i] /= 2.0 * SampleRate;
                m_FourierIm[i] /= 2.0 * SampleRate;
            }
        }
    }
}
