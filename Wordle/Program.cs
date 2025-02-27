// Wordle Program (Color Implemented)

int lim = 5;

// Get random word from a .txt file
Random random = new Random();
string[] words = File.ReadAllLines("5_letter_words");
int index = random.Next(words.Count());
string word = words[index];
word = word.ToUpper();

char[] wordOrder = word.ToCharArray();
int wordLength = word.Length;

for (int j = 0; j < lim; j++) {                      // Each guess iteration
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Guess a 5 letter word");
    string input = Console.ReadLine();
    input = input.ToUpper();
    char[] inputOrder = input.ToCharArray();

    if (input.Length != word.Length){
        Console.WriteLine("Guess a word with same length next time");
        break;
    }

    
    for (int k = 1; k <= wordLength; k++) {
        int pos = Array.IndexOf(wordOrder, inputOrder[k-1]);
        if (Char.Equals(wordOrder[k-1], inputOrder[k-1])) {  
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write(inputOrder[k-1]);
        }
        else if (pos > -1) {
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.Write(inputOrder[k-1]);
        }
        else {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.Write("-");
        }
    }
    Console.ForegroundColor = ConsoleColor.White;
    
    if (input == word){
        Console.WriteLine("");
        Console.WriteLine("Correct! The word was: " + word);
        break;
    }
    else if (j == 4){
        Console.WriteLine("");
        Console.WriteLine("The correct word was: " + word);
        break;
    }
    
}

