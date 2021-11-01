using Accord.Math.Optimization;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var fileText = File.ReadAllLines(Path.Combine(@"C:\Users\aexol\source\repos\Zadanie3\Zadanie3\test.csv"));
            var lines = fileText.Select(s => s.Split(",")).ToList();

            var parsedLines = lines.Select(line => line.Select(double.Parse).ToArray()).ToArray();

            var m = new Munkres(parsedLines);

            var success = m.Maximize();
            var maximumCost = m.Value;
            var maxCostString = maximumCost.ToString();
            var maxCostWithoutMinus = maxCostString.Remove(0, 1);

            stopWatch.Stop();
            var ts = stopWatch.ElapsedMilliseconds;
            Console.WriteLine(ts);
            Console.WriteLine(maxCostWithoutMinus);
            Console.ReadKey();
        }
    }
}
