namespace CSharpBasic.TestCases
{
    internal sealed class SquareRoot : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "SquareRoot";

        protected override void PerformTask(Random random)
        {
            Math.Sqrt(random.NextDouble());
        }
    }
}
