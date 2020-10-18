using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlgorithmExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // repeated word counter
            Console.WriteLine("---repeated word counter---");
            const string text = "Palabra repetida, veces dos veces. repetida tres veces!";
            foreach (var (key, value) in RepeatedWordCounter(text))
            {
                Console.WriteLine($"{key}: {value}");
            }

            // fibonacci double recursive
            Console.WriteLine("---fibonacci double recursive---");
            const int fibonacciValue = 9;
            Console.WriteLine(FibonacciRecursive(fibonacciValue));
        }

        private static Dictionary<string, int> RepeatedWordCounter(string text)
        {
            var normalize = Regex.Replace(text.ToLower(), "[,.!]", "");
            var separateWords = normalize.Split(" ");
            var dictionary = new Dictionary<string, int>();

            foreach (var word in separateWords)
            {
                dictionary[word] = dictionary.ContainsKey(word) ? ++dictionary[word] : dictionary[word] = 1;
            }

            return dictionary;
        }

        private static int FibonacciRecursive(int number)
        {
            if (number <= 1) return 1;
            return FibonacciRecursive(number - 1) + FibonacciRecursive(number - 2);
        }
    }
}