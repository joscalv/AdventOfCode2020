using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public class Day14 : IAdventOfCodeDay<ulong, ulong>
    {
        private readonly string[] _input;

        public Day14()
        {
            _input = File
                  .ReadAllText(Path.Combine("Inputs", "input14.txt"))
                  .Split("\n")
                  .Where(s => !string.IsNullOrEmpty(s))
                  .ToArray();
        }

        public ulong ExecutePart1()
        {
            Dictionary<int, ulong> memory = new Dictionary<int, ulong>();
            string mask = "";

            foreach (var input in _input)
            {
                if (input.StartsWith("mask"))
                {
                    var parts = input.Split(" = ");
                    mask = parts[1];
                }
                if (input.StartsWith("mem"))
                {
                    int startIndex = input.IndexOf('[') + 1;
                    int lenght = input.IndexOf(']') - startIndex;
                    int memoryDirection = int.Parse(input.Substring(startIndex, lenght));
                    ulong originalValue = ulong.Parse(input.Split(" = ")[1]);
                    ulong value = Day14Extensions.ApplyMask(originalValue, mask);
                    if (memory.ContainsKey(memoryDirection))
                    {
                        memory[memoryDirection] = value;
                    }
                    else
                    {
                        memory.Add(memoryDirection, value);
                    }
                }
            }

            ulong result = 0;
            foreach (var item in memory)
            {
                result = result + item.Value;
            }
            return result;

        }

        public ulong ExecutePart2(string[] commands)
        {
            Dictionary<ulong, ulong> memory = new Dictionary<ulong, ulong>();
            string mask = "";

            foreach (var input in commands)
            {
                if (input.StartsWith("mask"))
                {
                    var parts = input.Split(" = ");
                    mask = parts[1];
                }
                if (input.StartsWith("mem"))
                {
                    int startIndex = input.IndexOf('[') + 1;
                    int lenght = input.IndexOf(']') - startIndex;
                    var initialMemoryDirection = ulong.Parse(input.Substring(startIndex, lenght));
                    var memoryDirectionMasked = Day14Extensions.ApplyMask2(initialMemoryDirection, mask);
                    ulong value = ulong.Parse(input.Split(" = ")[1]);

                    foreach (var memoryDirection in memoryDirectionMasked)
                    {
                        if (memory.ContainsKey(memoryDirection))
                        {
                            memory[memoryDirection] = value;
                        }
                        else
                        {
                            memory.Add(memoryDirection, value);
                        }
                    }
                }
            }

            ulong result = 0;
            foreach (var item in memory)
            {
                result = result + item.Value;
            }
            return result;
        }

        public ulong ExecutePart2()
        {
            return ExecutePart2(_input);
        }
    }

    public static class Day14Extensions
    {
        public static ulong ApplyMask(ulong number, string mask)
        {
            var masks = GetMasks(mask);
            return (number & masks.andMask) | masks.orMask;
        }

        public static (ulong andMask, ulong orMask) GetMasks(string mask)
        {
            ulong andMask = 0;
            for (var i = 0; i < 30; i++)
            {
                andMask = (andMask << 1) | 1;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                andMask = (andMask << 1) | (ulong)(mask[i] == '0' ? 0 : 1);
            }

            ulong orMask = 0;
            for (int i = 0; i < mask.Length; i++)
            {
                orMask = (orMask << 1) | (ulong)(mask[i] == '1' ? 1 : 0);
            }

            return (andMask, orMask);
        }

        public static byte[] ValueToBits(ulong value)
        {
            byte[] result = new byte[36];
            for (int i = 0; i < 36; i++)
            {
                byte newBit = (byte)(value >> i & 1);
                result[i] = newBit;
            }
            return result;
        }

        public static ulong BitsToValue(byte[] bytes)
        {
            ulong result = 0; 
            for (int i = 0; i < bytes.Length; i++)
            {
                result = result << 1 | bytes[bytes.Length-1-i];
            }
            return result;
        }

        public static List<ulong> ApplyMask2(ulong value, string mask)
        {
            List<ulong> result = new List<ulong>();
            var maskChars = mask.ToCharArray();
            var numberOfX = maskChars.Count(c => c == 'x' || c == 'X');
            var resultLength = Math.Pow(2, numberOfX);

            var valueBytes = ValueToBits(value);
            for (int i = 0; i < resultLength; i++)
            {
                int xToReplace = 0;
                var resultJ = new byte[36];
                for (int j = 0; j < 36; j++)
                {
                    if (mask[35-j] == '0')
                    {
                        resultJ[j] = valueBytes[j];
                    }
                    else if (mask[35-j] == '1')
                    {
                        resultJ[j] = 1;
                    }
                    else if (mask[35-j] == 'x' || mask[35 - j] == 'X')
                    {
                        resultJ[j] = GetBitAtIndex(i, xToReplace);
                        xToReplace++;
                    }
                }
                result.Add(BitsToValue(resultJ));
            }

            return result;
        }

        public static byte GetBitAtIndex(int value, int index)
        {
            return (byte)(value >> index & 1);
        }
    }
}
