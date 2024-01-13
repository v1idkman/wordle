// Wordle Program (No Colours or Includes)

int lim = 5;
string word = "SUPER";
char[] wordOrder = word.ToCharArray();
int wordLength = word.Length;
string currentDisplay;

for (int i = 0; i < lim; i++) {                      // Each iteration of the guesses
    currentDisplay = String.Empty;        // Destroy currentDisplay with each iteration and rebuild, display
    Console.WriteLine("Guess a 5 letter word");
    string input = Console.ReadLine();
    input = input.ToUpper();
    char[] inputOrder = input.ToCharArray();

    if (input.Length != word.Length){
        Console.WriteLine("Guess a word with same length next time");
        break;
    }
    if (input == word){
        Console.WriteLine("Correct! The word was: " + word);
        break;
    }
    else if (i == 4){
        Console.WriteLine("The correct word was: " + word);
        break;
    }

    for (int j = 1; wordLength >= j; j++){           // Checking each letter and displaying correct and incorrect
        // Console.WriteLine(wordOrder + " " + inputOrder + " ");
        if (Char.Equals(wordOrder[j-1], inputOrder[j-1])){         // indexOutOfRanges
            currentDisplay = currentDisplay + inputOrder[j-1];  // Add current letter to currentDisplay
        }
        else{
            currentDisplay = currentDisplay + '-';            // Add '-' to currentDisplay
        }
    }
    
    Console.WriteLine(currentDisplay);
}
