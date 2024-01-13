// Wordle Program (Color Implemented)

int lim = 5;

// Get random word from a .txt file
Random random = new Random();
string[] words = File.ReadAllLines("5_letter_words");
int index = random.Next(words.Count());
string word = words[index];
word = word.ToUpper();
//Console.WriteLine(word); // correctly takes a word randomly

char[] wordOrder = word.ToCharArray();
int wordLength = word.Length;
/*
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
        if (Char.Equals(wordOrder[j-1], inputOrder[j-1])){
            currentDisplay = currentDisplay + inputOrder[j-1];  // Add current letter to currentDisplay
        }
        else{
            currentDisplay = currentDisplay + '-';            // Add '-' to currentDisplay
        }
    }
    
    Console.WriteLine(currentDisplay);
}
*/

for (int j = 0; j < lim; j++) {                      // Each guess iteration
    Console.WriteLine();
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
    else if (j == 4){
        Console.WriteLine("The correct word was: " + word);
        break;
    }

    
    for (int k = 1; k <= wordLength; k++) {
        int pos = Array.IndexOf(wordOrder, inputOrder[k-1]);
        //Console.WriteLine("wordOrder[k-1]: " + wordOrder[k-1] + " " + "inputOrder[k-1]" + inputOrder[k-1] + " pos: " + pos);
        if (Char.Equals(wordOrder[k-1], inputOrder[k-1])) {  
            Console.BackgroundColor = ConsoleColor.Black;      
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write(inputOrder[k-1]);
        }
        else if (pos > -1) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.Write(inputOrder[k-1]);
        }
        else {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.Write("-");
        }
        
    }
    Console.ResetColor();
    
}

