namespace CSharpBasic.TestCases
{
    internal sealed class FibonacciArray : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "FibonacciArray";

        protected override void PerformTask(Random random)
        {
            long count = random.NextInt64(0L, 20L);
            long[] fibs = new long[count];

            for(int i = 0; i < fibs.Length; ++i) {
                if(i == 0) {
                    fibs[i] = 0;
                    continue;
                }

                if(i == 1) {
                    fibs[i] = 1;
                    continue;
                }

                fibs[i] = fibs[i - 1] + fibs[i - 2];
            }
        }
    }
}
