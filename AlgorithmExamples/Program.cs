using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlgorithmExamples
{
    static class Program
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

            Console.WriteLine("---Get the largest number in the array---");
            var arrayOfNumbers = new[] {1, 30, 34, 60, 2, 55};
            Console.WriteLine(GetBiggest(arrayOfNumbers));

            Console.WriteLine("---Flatten array---");
            var nestedArray = new[]
            {
                new object[] {new object[] {4, 5, 6, new object[] {6, 7, 8}}},
                new object[] {2, 3},
                new object[] {4, 5, 6}
            };
            Console.WriteLine(nestedArray);
            Console.WriteLine(FlattenArray(nestedArray));
            
            Console.WriteLine("---Multi recursive---");
            Console.Write(MultiRecursive(3, 5));
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

        private static int GetBiggest(IEnumerable<int> arr) => arr.Aggregate((acc, el) => acc > el ? acc : el);

        private static object[] FlattenArray(object jaggedArray)
        {
            var flattenedArray = new List<object>();
            var jaggedArrayType = jaggedArray.GetType();
            var expectedType = typeof(int);

            if (jaggedArrayType.IsArray)
            {
                if (expectedType.IsAssignableFrom(jaggedArrayType.GetElementType()))
                    flattenedArray.AddRange((object[]) jaggedArray);
                else
                    flattenedArray.AddRange(((object[]) jaggedArray).SelectMany(FlattenArray));
            }
            else if (jaggedArrayType == expectedType)
            {
                flattenedArray.Add((int) jaggedArray);
            }
            else
            {
                return new object[0];
            }

            return flattenedArray.ToArray();
        }

        private static double MultiRecursive(int a, int b)
        {
            if (a == 0 || b == 0) return 0;
            return a + MultiRecursive(a, b - 1);
        }
    }
}