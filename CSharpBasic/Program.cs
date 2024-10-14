using CSharpBasic.TestCases;

namespace CSharpBasic
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.UtcNow;
            StreamWriter mainCSV = new StreamWriter(string.Format("csharp.{0}.main.{1}.csv", Environment.OSVersion.Platform, dateTime.ToFileTime()));
            mainCSV.WriteLine("Name,Iterations,Elapsed");

            List<BaseBenchmark> benchmarks = new List<BaseBenchmark> {
                new FourierTransform(),
                new SquareRoot(),
                new PowCosine(),
            };

            foreach(BaseBenchmark benchmark in benchmarks) {
                string name = benchmark.Name;
                int iterations = benchmark.MaxIterations;
                double elapsed = benchmark.RunBenchmark(out List<double> timings);

                Console.WriteLine("{0,-25}: {1:0.000000000}ms", name, elapsed);
                mainCSV.WriteLine("{0},{1},{2:0.000000000000}", name, iterations, elapsed);

                StreamWriter benchCSV = new StreamWriter(string.Format("csharp.{0}.bench.{1}.{2}.csv", Environment.OSVersion.Platform, name, dateTime.ToFileTime()));
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
