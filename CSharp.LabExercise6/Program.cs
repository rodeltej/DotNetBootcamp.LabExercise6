using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp.LabExercise6
{
    class Scrabble
    {
        public int totalScore { get; set; }

        private static Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            {'A', 1 }, {'E', 1 }, {'I', 1 }, {'O', 1 }, {'U', 1 }, {'L', 1 }, {'N', 1 }, {'R', 1 }, {'S', 1 }, {'T', 1 },
            {'D', 2 }, {'G', 2 },
            {'B', 3 }, {'C', 3 }, {'M', 3 }, {'P', 3 },
            {'F', 4 }, {'H', 4 }, {'V', 4 }, {'W', 4 }, {'Y', 4 },
            {'K', 5 },
            {'J', 8 }, {'X', 8 },
            {'Q', 10 }, {'Z', 10 }
        };

        private int points;
        public int Score(string input)
        {
            totalScore = 0;
            foreach (char letter in input)
            {
                letters.TryGetValue(letter, out points);
                totalScore += points;
            }
            return totalScore;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var answer = "y";
            Regex regex = new Regex("[~`,./;'[|{}:<>?=+_)(*&^%$#@!-]");


            while (answer.Trim().ToLower().Equals("y"))
            {

                bool wordInput = true;
                while (wordInput)
                {
                    Console.Write("Enter word: ");
                    string word = Console.ReadLine();
                    if (regex.IsMatch(word) || word.Any(char.IsDigit) || word.Any(char.IsWhiteSpace))
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("Input should not include spaces, numbers, or any special characters");
                    }
                    else
                    {
                        Scrabble scrabble = new Scrabble();
                        Console.WriteLine($"Total Score: {scrabble.Score(word.ToUpper())}");
                        wordInput = false;
                    }

                }

                Console.Write("\nDo you want to continue(y/n)? ");
                answer = Console.ReadLine();
                Console.WriteLine("");
            }

            
        }
    }
}
