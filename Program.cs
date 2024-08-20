using System.Diagnostics;

namespace Plinq
{
    internal class Program
    {
        static void Main()
        {
            var stopwatch = Stopwatch.StartNew();

            var collection = Enumerable.Range(0, 10).AsParallel()
                                                    .Select(LongTimeComputing)
                                                    .AsUnordered()
                                                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                    .ToList();

            foreach (var _ in collection) ;

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }

        static int LongTimeComputing(int x)
        {
            for (int i = 0; i < 100_000_000; i++)
            {
                x += i;
            }
            return x;
        }

    }
}
