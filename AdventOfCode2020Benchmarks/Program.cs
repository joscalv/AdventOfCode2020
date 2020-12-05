using System;
using System.Reflection;
using BenchmarkDotNet.Running;

namespace AdventOfCode2020Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<AdventOfCodeBenchmarks>();
            //BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
        }
    }
}
