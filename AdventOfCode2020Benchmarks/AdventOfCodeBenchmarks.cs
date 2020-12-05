using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode2020Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [MemoryDiagnoser]
    public class AdventOfCodeBenchmarks
    {
        private static readonly Day01 _day01= new Day01();
        private static readonly Day02 _day02= new Day02();
        private static readonly Day03 _day03= new Day03();
        private static readonly Day04 _day04= new Day04();
        private static readonly Day05 _day05= new Day05();

        [Benchmark]
        public void Day01_1() => _day01.ExecutePart1();

        [Benchmark]
        public void Day01_2() => _day01.ExecutePart2();
        
        [Benchmark]
        public void Day02_1() => _day02.ExecutePart1();

        [Benchmark]
        public void Day02_2() => _day02.ExecutePart2();
        
        [Benchmark]
        public void Day03_1() => _day03.ExecutePart1();

        [Benchmark]
        public void Day03_2() => _day03.ExecutePart2();
        
        [Benchmark]
        public void Day04_1() => _day04.ExecutePart1();

        [Benchmark]
        public void Day04_2() => _day04.ExecutePart2();
        
        [Benchmark]
        public void Day05_1() => _day05.ExecutePart1();

        [Benchmark]
        public void Day05_2() => _day05.ExecutePart2();
    }
}
