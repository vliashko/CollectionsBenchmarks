using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchPerfomance
{
    class Program
    {
        static void Main()
        {
            string s = "9";
            int count = 15;

            List<string> sNumbersList = new List<string>();
            HashSet<string> sNumbersHashSet = new HashSet<string>();

            // List load performance
            Stopwatch oListLoad = new Stopwatch();
            oListLoad.Start();
            for (int i = 0; i < count; i++)
                sNumbersList.Add(i.ToString());
            oListLoad.Stop();
            Console.WriteLine("List load time:" + oListLoad.Elapsed);

            // Hash Set load performance
            Stopwatch oHashSetLoad = new Stopwatch();
            oHashSetLoad.Start();
            for (int i = 0; i < count; i++)
                sNumbersHashSet.Add(i.ToString());
            oHashSetLoad.Stop();
            Console.WriteLine("Hash load time:" + oHashSetLoad.Elapsed);

            // List lookup performance
            Stopwatch oListWatch = new Stopwatch();
            oListWatch.Start();
            if (sNumbersList.Contains(s))
                Console.Write("List lookup time: ");
            oListWatch.Stop();
            Console.WriteLine(oListWatch.Elapsed);

            // Hash set lookup performance
            Stopwatch oHashSetWatch = new Stopwatch();
            oHashSetWatch.Start();
            if (sNumbersHashSet.Contains(s))
                Console.Write("Hash lookup time: ");
            oHashSetWatch.Stop();
            Console.WriteLine(oHashSetWatch.Elapsed);
    
            Console.Read();
        }
    }
}
