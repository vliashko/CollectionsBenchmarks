using BenchmarkDotNet.Attributes;

namespace CollectionsBenchmarks
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly TestingClassForList _testClass = new TestingClassForList();

        //[Benchmark]
        //public void CallMemoryAllocation1K() => _testClass.MemoryAllocation1K();

        //[Benchmark]
        //public void CallMemoryAllocation10K() => _testClass.MemoryAllocation10K();

        //[Benchmark]
        //public void CallMemoryAllocation100K() => _testClass.MemoryAllocation100K();

        //[Benchmark]
        //public void CallMemoryAllocation1K() => _testClass.MemoryAllocation1K_Capacity();

        //[Benchmark]
        //public void CallMemoryAllocation10K() => _testClass.MemoryAllocation10K_Capacity();

        //[Benchmark]
        //public void CallMemoryAllocation100K() => _testClass.MemoryAllocation100K_Capacity();

        [Params(1000, 10 * 1000, 100 * 1000)]
        public int iterations = 0;

        private SimpleAllocations sa = new SimpleAllocations();

        [Benchmark]
        public void TestChunkedList()
        {
            sa.TestChunkedList(iterations);
        }
    }
}
