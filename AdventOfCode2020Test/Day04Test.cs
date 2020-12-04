using AdventOfCode;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day04Test
    {
        private readonly string[] _lines = new[]{"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
"byr:1937 iyr:2017 cid:147 hgt:183cm",
"",
"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
"hcl:#cfa07d byr:1929",
"",
"hcl:#ae17e1 iyr:2013",
"eyr:2024",
"ecl:brn pid:760753108 byr:1931",
"hgt:179cm",
"",
"hcl:#cfa07d eyr:2025 pid:166559648",
"iyr:2011 ecl:brn hgt:59in"};
        
        private readonly string[] _invalidPassports = new[]{"eyr:1972 cid:100",
"hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926",
"",
"iyr:2019",
"hcl:#602927 eyr:1967 hgt:170cm",
"ecl:grn pid:012533040 byr:1946",
"",
"hcl:dab227 iyr:2012",
"ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277",
"",
"hgt:59cm ecl:zzz",
"eyr:2038 hcl:74454a iyr:2023",
"pid:3556412378 byr:2007"};


        private readonly string[] _validPassports = new[]{"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
"hcl:#623a2f",
"",
"eyr:2029 ecl:blu cid:129 byr:1989",
"iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
"",
"hcl:#888785",
"hgt:164cm byr:2001 iyr:2015 cid:88",
"pid:545766238 ecl:hzl",
"eyr:2022",
"",
"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719" };


        [Fact]
        public void ParsePassport()
        {
            var passportString = new[] { _lines[0], _lines[1] };

            var passport = PassportUtils.ParsePassport(passportString);

            passport.ecl.Should().Be("gry");
            passport.pid.Should().Be("860033327");
            passport.eyr.Should().Be("2020");
            passport.hcl.Should().Be("#fffffd");
            passport.byr.Should().Be("1937");
            passport.iyr.Should().Be("2017");
            passport.cid.Should().Be("147");
            passport.hgt.Should().Be("183cm");
        }

        [Fact]
        public void ParseSeveralPassports()
        {
            var passports = PassportUtils.ParsePassports(_lines);
            passports.Should().HaveCount(4);
        }

        [Fact]
        public void BasicChecks()
        {
            var passports = PassportUtils.ParsePassports(_lines).ToList();
            passports[0].IsValidBasicChecks().Should().Be(true);
            passports[1].IsValidBasicChecks().Should().Be(false);
            passports[2].IsValidBasicChecks().Should().Be(true);
            passports[3].IsValidBasicChecks().Should().Be(false);
        }
        
        [Fact]
        public void InvalidPassports()
        {
            var passports = PassportUtils.ParsePassports(_invalidPassports).ToList();
            passports
                .ForEach(p => p.IsValidComplexChecks().Should().BeFalse());
        }
        
        [Fact]
        public void ValidPassports()
        {
            var passports = PassportUtils.ParsePassports(_validPassports).ToList();
            passports
                .ForEach(p => p.IsValidComplexChecks().Should().BeTrue());
        }

        [Fact]
        public void FieldsMustBeValid()
        {
            PassportUtils.IsHeight("60in").Should().BeTrue();
            PassportUtils.IsHeight("190cm").Should().BeTrue();
            PassportUtils.IsHeight("190in").Should().BeFalse();
            PassportUtils.IsHeight("190").Should().BeFalse();
            
            PassportUtils.IsHexColor("#123abc").Should().BeTrue();
            PassportUtils.IsHexColor("#123abz").Should().BeFalse();
            PassportUtils.IsHexColor("123abc").Should().BeFalse();

            PassportUtils.IsEyesColor("brn").Should().BeTrue();
            PassportUtils.IsEyesColor("wat").Should().BeFalse();

            PassportUtils.IsPid("000000001").Should().BeTrue();
            PassportUtils.IsPid("0123456789").Should().BeFalse();
        }

        [Fact]
        public void TestPart1()
        {
            int part1Solution = 216;
            var day4 = new Day04();
            Assert.Equal(part1Solution, day4.ExecutePart1());
        }

        [Fact]
        public void TestPart2()
        {
            int part2Solution = 150;
            var day4 = new Day04();
            Assert.Equal(part2Solution, actual: day4.ExecutePart2());
        }
    }
}