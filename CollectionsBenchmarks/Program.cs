using BenchmarkDotNet.Running;

namespace CollectionsBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
