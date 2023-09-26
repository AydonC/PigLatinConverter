using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PigLatinConverter
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter an English sentence or word:");
            string input = Console.ReadLine();
            string pigLatinSentence = ConvertToPigLatin(input);
            Console.WriteLine("In Pig Latin the word would be: " + pigLatinSentence);
            RestartGame();

        }

        static void RestartGame()
        {

            Console.WriteLine("Would you like to try again? yes or no?");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                Main();
            }
            else if (answer == "no")
            {
                Console.WriteLine("Thank you for playing!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please Enter valid answer!");
                RestartGame();
            }
        

        }

        static string ConvertToPigLatin(string input)
        {
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // Check if the word contains only letters
                if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {

                        int firstVowelIndex = FindFirstVowelIndex(word);
                        string prefix = word.Substring(0, firstVowelIndex);
                        string suffix = word.Substring(firstVowelIndex);

                        words[i] = suffix + prefix + "ay";
                    
                }
                else
                {
                    Console.WriteLine("Please enter valid word or sentence please!");
                    RestartGame();
                }
            }

            return string.Join(" ", words);
        }

        static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            return Array.IndexOf(vowels, char.ToLower(c)) != -1;
        }

        static int FindFirstVowelIndex(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    return i;
                }
            }
            return -1; // If no vowel is found 
        }
    }

}

