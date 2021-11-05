using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace ReadOnlyAndImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(10);

            ReadOnlyCollection<int> readonlyList = list.AsReadOnly();

            Console.WriteLine($"Size: {readonlyList.Count}");

            list.Add(1);

            Console.WriteLine($"Size: {readonlyList.Count}");

            Console.Read();
        }
    }
}
