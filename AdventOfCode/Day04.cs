using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }
    }

    public static class PassportUtils
    {
        public static bool IsValidBasicChecks(this Passport passport)
        {
            return
                !string.IsNullOrEmpty(passport.byr)
            && !string.IsNullOrEmpty(passport.iyr)
            && !string.IsNullOrEmpty(passport.eyr)
            && !string.IsNullOrEmpty(passport.hgt)
            && !string.IsNullOrEmpty(passport.hcl)
            && !string.IsNullOrEmpty(passport.ecl)
            && !string.IsNullOrEmpty(passport.pid);

        }

        public static bool IsValidComplexChecks(this Passport passport)
        {
            return
                IsIntMinMax(passport.byr, 192, 2002)
                && IsIntMinMax(passport.iyr, 2010, 2020)
                && IsIntMinMax(passport.eyr, 2020, 2030)
            && IsHeight(passport.hgt)
            && IsHexColor(passport.hcl)
            && IsEyesColor(passport.ecl)
            && IsPid(passport.pid);
        }

        public static bool IsPid(string pid)
        {
            return IsIntMinMax(pid, 0, 999999999, 9);
        }

        private static readonly HashSet<string> _colors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        public static bool IsEyesColor(string color)
        {
            return _colors.Contains(color);
        }

        public static bool IsHexColor(string color)
        {
            return !string.IsNullOrEmpty(color) && Regex.IsMatch(color, "^#([a-fA-F0-9]{6})$");
        }

        public static bool IsHeight(string height)
        {
            if (string.IsNullOrEmpty(height))
            {
                return false;
            }

            if (height.EndsWith("cm"))
            {
                return IsIntMinMax(height.Substring(0, height.Length - 2), 150, 193);
            }
            else if (height.EndsWith("in"))
            {
                return IsIntMinMax(height.Substring(0, height.Length - 2), 59, 76);
            }
            return false;
        }

        public static bool IsIntMinMax(string value, int min, int max, int digits = 0)
        {
            return
                !string.IsNullOrEmpty(value)
                && (value.Length == digits || digits == 0)
                && int.TryParse(value, out var parsed)
                && parsed >= min
                && parsed <= max;
        }

        public static Passport ParsePassport(string[] lines)
        {
            var passport = new Passport();
            var passportType = typeof(Passport);
            lines
                .SelectMany(line => line.Split(' '))
                .Select(ParseKvp)
                .ToList()
                .ForEach(kvps =>
                {
                    passportType.GetProperty(kvps.key).SetValue(passport, kvps.value);
                });

            return passport;
        }

        public static IEnumerable<Passport> ParsePassports(string[] lines)
        {
            var passportLines = new List<List<string>>();
            passportLines.Add(new List<string>());

            var result = new List<Passport>();

            foreach (var line in lines)
            {
                if (line != string.Empty)
                {
                    passportLines.Last().Add(line);
                }
                else if (line == string.Empty && passportLines.Last().Any())
                {
                    passportLines.Add(new List<string>());
                }
            }

            result = passportLines
                .Select(l => ParsePassport(l.ToArray()))
                .Where(p => p != null)
                .ToList();

            return result;
        }

        private static (string key, string value) ParseKvp(string kvp)
        {
            var splited = kvp.Split(':');
            return (splited[0], splited[1]);
        }
    }

    public class Day04
    {
        private readonly string[] _lines;
        private readonly IEnumerable<Passport> _passports;

        public Day04()
        {
            _lines = File
                  .ReadAllLines(Path.Combine("Inputs", "input04.txt"))
                  .ToArray();
            _passports = PassportUtils.ParsePassports(_lines);
        }

        public long ExecutePart1()
        {
            var passports = PassportUtils.ParsePassports(_lines);

            return passports.Count(p => p.IsValidBasicChecks());
        }

        public long ExecutePart2()
        {
            return _passports.Count(p => p.IsValidComplexChecks());
        }
    }
}
