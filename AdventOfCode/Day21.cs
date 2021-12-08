using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace AdventOfCode
{

    public class Day21 : IAdventOfCodeDay<long, string>
    {
        private readonly List<(string[] ingredients, string[] allergens)> _input;

        public Day21()
        {
            var input = File
                .ReadAllText(Path.Combine("Inputs", "input21.txt"))
                .Split("\n")
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray();
            _input = Day21Extensions.Parse(input);
        }

        public long ExecutePart1()
        {

            return ExecutePart1(_input);
        }

        public static long ExecutePart1(List<(string[] ingredients, string[] allergens)> recipes)
        {
            var list = GetAllergensByIngredient(recipes);

            var ingredientsWithAllergen = list.Select(i => i.incredient).ToHashSet();

            var ingredientsWithNoAllergen = recipes.SelectMany(r => r.ingredients)
                .Where(i => ingredientsWithAllergen.Contains(i) == false).ToList();

            return ingredientsWithNoAllergen.Count;
        }

        public static string ExecutePart2(List<(string[] ingredients, string[] allergens)> recipes)
        {
            var list = GetAllergensByIngredient(recipes);

            var result = String.Join(",", list.Select(i => i.incredient));
            return result;
        }

        public static List<(string incredient, string allergen)> GetAllergensByIngredient(List<(string[] ingredients, string[] allergens)> recipes)
        {
            var allergens = recipes.SelectMany(r => r.allergens).Distinct().ToList();
            Dictionary<string, List<string>> candidatesByAllergen = new Dictionary<string, List<string>>();

            foreach (var allergen in allergens)
            {
                var recipesWithAllergen = recipes.Where(r => r.allergens.Contains(allergen)).ToList();
                var allIngredients = recipesWithAllergen.SelectMany(r => r.ingredients).ToList();
                var candidateIngredientsForAllergen = allIngredients.Where(i =>
                     recipesWithAllergen.Any(r => r.ingredients.Contains(i) == false) == false).Distinct().ToList();

                candidatesByAllergen.Add(allergen, candidateIngredientsForAllergen);
            }

            while (candidatesByAllergen.Values.Any(c => c.Count > 1))
            {
                var singles = candidatesByAllergen.Values.Where(c => c.Count == 1).Select(c => c.First());
                foreach (var single in singles)
                {
                    foreach (var values in candidatesByAllergen.Values.Where(c => c.Count > 1 && c.Contains(single)))
                    {
                        values.Remove(single);
                    }
                }
            }

            var canonicalList = candidatesByAllergen
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => (ingredient: kvp.Value.First(), allergen: kvp.Key))
                .ToList();

            return canonicalList;
        }

        public string ExecutePart2()
        {
            return ExecutePart2(_input);
        }
    }

    public static class Day21Extensions
    {
        public static List<(string[] ingredients, string[] allergens)> Parse(string[] input)
        {
            return input.Select(line =>
                {
                    var recipeParts = line.Replace(")", "").Split("(contains ");
                    return (recipeParts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        recipeParts[1].Split(", ", StringSplitOptions.RemoveEmptyEntries));
                })
                .ToList();
        }
    }
}
