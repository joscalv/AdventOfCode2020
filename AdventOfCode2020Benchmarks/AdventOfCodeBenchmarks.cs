﻿using System;
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
        private static readonly Day01 Day01= new Day01();
        private static readonly Day02 Day02= new Day02();
        private static readonly Day03 Day03= new Day03();
        private static readonly Day04 Day04= new Day04();
        private static readonly Day05 Day05= new Day05();
        private static readonly Day06 Day06= new Day06();
        private static readonly Day07 Day07= new Day07();
        private static readonly Day08 Day08= new Day08();
        private static readonly Day08Simpler Day08Simpler = new Day08Simpler();
        private static readonly Day09 Day09 = new Day09(); 
        private static readonly Day10 Day10 = new Day10();

        [Benchmark]
        public void Day01_1() => Day01.ExecutePart1();

        [Benchmark]
        public void Day01_2() => Day01.ExecutePart2();
        
        [Benchmark]
        public void Day02_1() => Day02.ExecutePart1();

        [Benchmark]
        public void Day02_2() => Day02.ExecutePart2();
        
        [Benchmark]
        public void Day03_1() => Day03.ExecutePart1();

        [Benchmark]
        public void Day03_2() => Day03.ExecutePart2();
        
        [Benchmark]
        public void Day04_1() => Day04.ExecutePart1();

        [Benchmark]
        public void Day04_2() => Day04.ExecutePart2();
        
        [Benchmark]
        public void Day05_1() => Day05.ExecutePart1();

        [Benchmark]
        public void Day05_2() => Day05.ExecutePart2();
        
        [Benchmark]
        public void Day06_1_Loop() => Day06.ExecutePart1();

        [Benchmark]
        public void Day06_1_Linq() => Day06.ExecutePart2Linq(); 
        
        [Benchmark]
        public void Day06_2_Loop() => Day06.ExecutePart1();

        [Benchmark]
        public void Day06_2_Linq() => Day06.ExecutePart2Linq();

        [Benchmark]
        public void Day07_1() => Day07.ExecutePart1();

        [Benchmark]
        public void Day07_2() => Day07.ExecutePart2();

        [Benchmark]
        public void Day08_1() => Day08.ExecutePart1();

        [Benchmark]
        public void Day08_2() => Day08.ExecutePart2();
        
        [Benchmark]
        public void Day08Simpler_1() => Day08Simpler.ExecutePart1();

        [Benchmark]
        public void Day08Simpler_2() => Day08Simpler.ExecutePart2();
    }
}
