using System.Collections.Generic;

namespace CollectionsBenchmarks
{
    public class TestingClassForList
    {
        private List<int> _list;

        public void MemoryAllocation1K()
        {
            _list = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                _list.Add(i);
            }
        }

        public void MemoryAllocation10K()
        {
            _list = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                _list.Add(i);
            }
        }

        public void MemoryAllocation100K()
        {
            _list = new List<int>();

            for (int i = 0; i < 100000; i++)
            {
                _list.Add(i);
            }
        }

        public void MemoryAllocation1K_Capacity()
        {
            _list = new List<int>(1000);

            for (int i = 0; i < 1000; i++)
            {
                _list.Add(i);
            }
        }

        public void MemoryAllocation10K_Capacity()
        {
            _list = new List<int>(10000);

            for (int i = 0; i < 10000; i++)
            {
                _list.Add(i);
            }
        }

        public void MemoryAllocation100K_Capacity()
        {
            _list = new List<int>(100000);

            for (int i = 0; i < 100000; i++)
            {
                _list.Add(i);
            }
        }
    }
}
