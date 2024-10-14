
namespace CSharpBasic.TestCases
{
    internal sealed class QuakeInverseSqrt : BaseBenchmark
    {
        public override int MaxIterations => 5120;
        public override string Name => "QuakeInverseSqrt";

        protected override void PerformTask(Random random)
        {
            double value = random.NextDouble();
            double xhalf = 0.5 * value;
            ulong i = BitConverter.DoubleToUInt64Bits(value);
            i = 0x5FE6EC85E7DE30DA - (i >> 1);
            double result = BitConverter.UInt64BitsToDouble(i);
            result = result * (1.5 - (xhalf * result * result));
            result = result * (1.5 - (xhalf * result * result));
        }
    }
}
