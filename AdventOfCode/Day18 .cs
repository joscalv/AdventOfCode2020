using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{

    public class Day18 : IAdventOfCodeDay<long, long>
    {
        private readonly string[] _input;

        public Day18()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input18.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .ToArray();
        }

        public long ExecutePart1()
        {
            long value = 0;
            foreach (var operation in _input)
            {
                value += Calc(operation);
            }

            return value;
        }

        public long ExecutePart2()
        {
            long value = 0;
            foreach (var operation in _input)
            {
                value += CalcPrecedence(operation);
            }

            return value;
        }

        public static long Calc(string input)
        {
            return Calc(Prepare(input), 0, out _);
        }

        public static long Calc(string[] input, int startIndex, out int endIndex)
        {
            var acc = 0L;
            Func<long, long, long> currentOperation = (long a, long b) => b;
            endIndex = startIndex;

            while (endIndex < input.Length)
            {
                if (input[endIndex] == "+")
                {
                    currentOperation = (long a, long b) => a + b;
                }
                else if (input[endIndex] == "*")
                {
                    currentOperation = (long a, long b) => a * b;
                }
                else if (input[endIndex] == "(")
                {
                    acc = currentOperation(acc, Calc(input, endIndex + 1, out var newIndex));
                    endIndex = newIndex;
                }
                else if (input[endIndex] == ")")
                {
                    return acc;
                }
                else
                {
                    acc = currentOperation(acc, int.Parse(input[endIndex]));
                }

                endIndex++;
            }

            return acc;
        }

        public static long CalcPrecedence(string input)
        {

            return CalcPrecedence(Prepare(input));
        }

        public static string[] Prepare(string input)
        {
            List<string> prepared = new List<string>();
            StringBuilder current = new StringBuilder();
            foreach (var c in input)
            {
                if (c is >= '0' and <= '9')
                {
                    current.Append(c);
                }
                else if (c is '+' or '*' or '(' or ')')
                {
                    if (current.Length > 0)
                    {
                        prepared.Add(current.ToString());
                        current.Clear();
                    }
                    prepared.Add($"{c}");
                }
            }

            if (current.Length > 0)
            {
                prepared.Add(current.ToString());
            }

            return prepared.ToArray();
        }

        public static long CalcPrecedence(string[] input)
        {
            var operation = input.ToArray();

            while (operation.Length > 1)
            {
                operation = ExecuteAllSubOperations(operation);
                operation = ExecuteAllOperations(operation, "+");
                operation = ExecuteAllOperations(operation, "*");

            }
            return long.Parse(operation.First());

        }

        private static string[] ExecuteAllSubOperations(string[] operation)
        {
            while (operation.Any(op => op == "("))
            {
                int deep = 0;
                int start = 0;
                int end = 0;
                for (int i = 0; i < operation.Length; i++)
                {
                    if (operation[i] == "(")
                    {
                        if (deep == 0)
                        {
                            start = i;
                        }
                        deep++;
                    }
                    if (operation[i] == ")")
                    {
                        if (deep == 1)
                        {
                            end = i;
                        }
                        deep--;
                    }
                }

                var subOperation = operation.Take(new Range(start + 1, end)).ToArray();
                var subResult = CalcPrecedence(subOperation);
                operation = ReplaceInOperation(operation, subResult, start, end);
            }

            return operation;
        }

        private static string[] ExecuteAllOperations(string[] formula, string operation)
        {
            var currentOperation = formula.ToArray();
            var isChanged = false;
            do
            {
                isChanged = false;
                for (int i = 0; i < currentOperation.Length - 2 && !isChanged; i++)
                {
                    if (long.TryParse(currentOperation[i], out var op1) && currentOperation[i + 1] == operation &&
                        long.TryParse(currentOperation[i + 2], out var op2))
                    {
                        var result = operation == "+" ? op1 + op2 : op1 * op2;
                        currentOperation = ReplaceInOperation(currentOperation, result, i, i + 2);
                        isChanged = true;
                    }
                }
            } while (isChanged);

            return currentOperation;
        }

        private static string[] ReplaceInOperation(string[] operation, long value, int start, int end)
        {
            return operation.Take(start).Append($"{value}")
                .Concat(operation.TakeLast(operation.Length - end - 1)).ToArray();
        }
    }
}
