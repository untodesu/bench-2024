namespace CSharpBasic.TestCases
{
    internal sealed class FibonacciRecursive : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "FibonacciRecursive";

        private long Fib(long order)
        {
            if(order <= 1L)
                return order;
            return Fib(order - 1) + Fib(order - 2);
        }

        protected override void PerformTask(Random random)
        {
            // Fib(random.NextInt64(0L, 20L));
            Fib(20L);
        }
    }
}
