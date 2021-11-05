using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CollectionsBenchmarks
{
    public class SimpleAllocations
	{
		private ChunkedIntList _chunkedList;

		public void TestChunkedList(int elements)
		{
			_chunkedList = new ChunkedIntList();

			for (int i = 0; i < elements; i++)
			{
				_chunkedList.Add(i);
			}
		}
	}

	public class ChunkedIntList
	{
		private const int CHUNK_SIZE = 20000;

		private static readonly MyArrayPool<int[]> _pool = new MyArrayPool<int[]>(() => new int[CHUNK_SIZE], 10);

		private readonly List<int[]> _chunks = new List<int[]>();

		private int length = 0;

		private int GetChunkIndex(int offset)
		{
			return offset / CHUNK_SIZE;
		}

		private int GetOffsetInChunk(int offset)
		{
			return offset % CHUNK_SIZE;
		}

		public int this[int index]
		{
			get
			{
				return _chunks[GetChunkIndex(index)][GetOffsetInChunk(index)];
			}
		}

		public int Count => length;

		public bool IsReadOnly => true;

		public void Add(int item)
		{
			if (length % CHUNK_SIZE == 0)
			{
				_chunks.Add(_pool.TakeObject());
			}

			_chunks[GetChunkIndex(length)][GetOffsetInChunk(length)] = item;

			length++;
		}

		public void Clear()
		{
			_chunks.Clear();

			length = 0;
		}
	}

	public class MyArrayPool<T>
	{
		private readonly ConcurrentBag<T> _pool;
		private readonly Func<T> _factory;
		private readonly int _maxArraysInPool;

		public MyArrayPool(Func<T> factory, int maxArraysInPool)
		{
			_pool = new ConcurrentBag<T>();
			_factory = factory;
			_maxArraysInPool = maxArraysInPool;
		}

		public T TakeObject()
		{
            if (_pool.TryTake(out T result))
            {
                return result;
            }

            return _factory();
		}

		public void ReturnObject(T value)
		{
			if (_pool.Count < _maxArraysInPool)
			{
				_pool.Add(value);
			}
		}
	}
}
