using System;
using System.Collections.Generic;

namespace ForeachWithoutIEnumerable
{
	public class Program
	{
		public static void Main()
		{
			var collection = new AmazingCollection();

			foreach (var element in collection)
			{
				Console.WriteLine(element);
			}
		}
	}

	public class AmazingCollection
	{
		public List<int> Data = new List<int> { 1, 2, 3, 4, 5 };

		public AmazingEnumerator GetEnumerator()
		{
			return new AmazingEnumerator(this);
		}
	}

	public class AmazingEnumerator
	{
		private readonly AmazingCollection _myCollection;
		private int _pointer = -1;

		public AmazingEnumerator(AmazingCollection collection)
		{
			_myCollection = collection;
		}

		public int Current => _myCollection.Data[_pointer];

		public bool MoveNext() => ++_pointer < _myCollection.Data.Count;
	}
}
