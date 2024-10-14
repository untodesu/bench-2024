namespace CSharpBasic.TestCases
{
    internal sealed class PowCosine : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "PowCosine";

        protected override void PerformTask(Random random)
        {
            Math.Pow(Math.Cos(2.0 * Math.PI * random.NextDouble()), random.NextDouble());
        }
    }
}
