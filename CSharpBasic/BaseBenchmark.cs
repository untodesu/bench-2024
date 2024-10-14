using System.Diagnostics;

namespace CSharpBasic
{
    /// <summary>
    /// This class represents a single test case that
    /// is going to be run multiple times and its runtime
    /// will be averaged to produce general result
    /// </summary>
    internal abstract class BaseBenchmark
    {
        /// <summary>
        /// This represents the total amount of iterations a specific
        /// test case needs to fully reach the average timestamp. This can
        /// be adjusted for heavyweight test cases to take less time
        /// </summary>
        public abstract int MaxIterations { get; }

        /// <summary>
        /// A PascalCase name used to save averaged timings into a CSV
        /// file and also to save per-iteration timings into a separate
        /// file for plotting a graph somewhere like MATLAB
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// This method is called numerous times and it's runtime
        /// is measured, averaged and then saved into a CSV file
        /// </summary>
        /// <param name="random">Entropy source</param>
        /// <returns></returns>
        protected abstract void PerformTask(Random random);

        /// <summary>
        /// Performs execution time measurement
        /// </summary>
        /// <param name="timings">A list of per-iteration runtimes</param>
        /// <returns>Average value of all iteration runtimes</returns>
        public double RunBenchmark(out List<double> timings)
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);
            Stopwatch stopwatch = new Stopwatch();

            timings = new List<double>();
            timings.EnsureCapacity(MaxIterations);

            for(int i = 0; i < MaxIterations; ++i) {
                stopwatch.Restart();
                PerformTask(random);
                timings.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            return timings.Average();
        }
    }
}
