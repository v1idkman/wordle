// Wordle Program with Colors
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static string GetRandomWordFromFile()
    {
        string filePath = "5_letter_words"; 
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Word file not found!");
            return "SUPER"; // use as default word
        }
        string[] allWords = File.ReadAllLines(filePath);

        if (allWords.Length == 0)
        {
            Console.WriteLine("No words found in the file!");
            return "SUPER"; // Fallback word if file is empty
        }
        
        Random random = new Random();
        
        string randomWord = allWords[random.Next(allWords.Length)];
        
        return randomWord.ToUpper();
    }

    static void Main()
    {
        int lim = 5;
        string word = GetRandomWordFromFile();
        char[] wordOrder = word.ToCharArray();
        int wordLength = word.Length;

        for (int i = 0; i < lim; i++)
        {                      
            Console.WriteLine("Guess a 5 letter word");
            string input = Console.ReadLine();
            input = input.ToUpper();
            char[] inputOrder = input.ToCharArray();

            if (input.Length != word.Length)
            {
                Console.WriteLine("Guess a word with same length next time");
                break;
            }
            if (input == word)
            {
                Console.WriteLine("Correct! The word was: " + word);
                break;
            }
            else if (i == 4)
            {
                Console.WriteLine("The correct word was: " + word);
                break;
            }

            List<char> remainingChars = new List<char>(wordOrder);

            // First pass: Check for exact matches (green) and mark them
            bool[] exactMatches = new bool[wordLength];
            for (int j = 0; j < wordLength; j++)
            {
                if (inputOrder[j] == wordOrder[j])
                {
                    exactMatches[j] = true;
                    remainingChars.Remove(inputOrder[j]);
                }
            }

            // Display the result with colors
            for (int j = 0; j < wordLength; j++)
            {
                if (exactMatches[j])
                {
                    // Green for correct position
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(inputOrder[j]);
                }
                else if (remainingChars.Contains(inputOrder[j]))
                {
                    // Yellow for correct letter, wrong position
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(inputOrder[j]);
                    remainingChars.Remove(inputOrder[j]); // Remove to handle duplicates correctly
                }
                else
                {
                    // Red for letter not in word
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(inputOrder[j]);
                }
            }
            
            // Reset color and move to next line
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
