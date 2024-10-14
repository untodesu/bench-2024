using CSharpBasic.TestCases;

namespace CSharpBasic
{
    internal sealed class Program
    {

#if DEBUG
        private const string Configuration = "Debug";
#else
        private const string Configuration = "Release";
#endif

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

            long unixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            StreamWriter mainCSV = new StreamWriter(string.Format("csharp.{0}.{1}.main.{2}.csv",
                Environment.OSVersion.Platform, Configuration, unixSeconds));
            mainCSV.WriteLine("Name,Iterations,Elapsed");

            List<BaseBenchmark> benchmarks = new List<BaseBenchmark> {
                new FibonacciArray(),
                new FibonacciRecursive(),
                new FourierTransform(),
                new SquareRoot(),
                new QuakeInverseSqrt(),
                new PowCosine(),
            };

            foreach(BaseBenchmark benchmark in benchmarks) {
                string name = benchmark.Name;
                int iterations = benchmark.MaxIterations;
                double elapsed = benchmark.RunBenchmark(out List<double> timings);

                Console.WriteLine("{0,-25}: {1:0.000000000}ms", name, elapsed);
                mainCSV.WriteLine("{0},{1},{2:0.000000000000}", name, iterations, elapsed);

                StreamWriter benchCSV = new StreamWriter(string.Format("csharp.{0}.{1}.bench.{2}.{3}.csv",
                    Environment.OSVersion.Platform, Configuration, name, unixSeconds));
                benchCSV.WriteLine("Iteration,ET");

                for(int i = 0; i < timings.Count; ++i) {
                    benchCSV.WriteLine("{0},{1:0.000000000000}", i, timings[i]);
                }

                benchCSV.Dispose();
            }

            mainCSV.Dispose();
        }
    }
}
