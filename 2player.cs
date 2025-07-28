using System.Text.Json;

internal class TwoPlayer
{
    static int Player1Wins = 0;
    static int Player2Wins = 0;

    public static void Main()
    {
        LoadGame();
        Console.WriteLine("Rock, Paper, Scissors");
        Console.WriteLine($"Player 1 at {Player1Wins} wins");
        Console.WriteLine($"Player 2 at {Player2Wins} wins");
        Console.WriteLine("Player 1, pick a hand");
        string playerOneHand = ChooseHand();
        Console.WriteLine("Player 2, pick a hand");
        string playerTwoHand = ChooseHand();
        Console.WriteLine($"Player 1 selected {playerOneHand}.");
        Console.WriteLine($"Player 2 selected {playerTwoHand}.");
        if (playerOneHand == playerTwoHand)
        {
            Console.WriteLine("You tied!");
        }
        else if (playerOneHand == "rock" && playerTwoHand == "paper")
        {
            Console.WriteLine("Player 2 wins!");
            Player2Wins++;
        }
        else if (playerOneHand == "paper" && playerTwoHand == "scissors")
        {
            Console.WriteLine("Player 2 wins!");
            Player2Wins++;
        }
        else if (playerOneHand == "scissors" && playerTwoHand == "rock")
        {
            Console.WriteLine("Player 2 wins!");
            Player2Wins++;
        }
        else if (playerTwoHand == "rock" && playerOneHand == "paper")
        {
            Console.WriteLine("Player 1 wins!");
            Player1Wins++;
        }
        else if (playerTwoHand == "paper" && playerOneHand == "scissors")
        {
            Console.WriteLine("Player 1 win!");
            Player1Wins++;
        }
        else if (playerTwoHand == "scissors" && playerOneHand == "rock")
        {
            Console.WriteLine("Player 1 win!");
            Player1Wins++;
        }
        SaveGame();
        Console.WriteLine($"Player 1 at {Player1Wins} wins");
        Console.WriteLine($"Player 2 at {Player2Wins} wins");
        Console.Write("Play again? y/n");
        char consoleInput = Console.ReadKey(true).KeyChar;
        Console.WriteLine();
        if (consoleInput == 'n')
        {
            if (Player1Wins == Player2Wins)
            {
                Console.WriteLine("No winners to be found here");
            }
            if (Player1Wins > Player2Wins)
            {
                Console.WriteLine(
                    "Player 1 takes it all! Now call your parents and tell them the good news."
                );
            }
            if (Player2Wins > Player1Wins)
            {
                Console.WriteLine(
                    "Player 2 takes it all! Now call your parents and tell them the good news."
                );
            }
            return;
        }
        Console.Clear();
        Main();
    }

    static string ChooseHand()
    {
        Console.WriteLine("Choose a Hand");
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Paper");
        Console.WriteLine("3. Scissors");

        char? userInput = Console.ReadKey(true).KeyChar;

        if (userInput == '1')
        {
            return "rock";
        }
        else if (userInput == '2')
        {
            return "paper";
        }
        else if (userInput == '3')
        {
            return "scissors";
        }

        Console.WriteLine("Invalid selection. Please select a hand");
        ChooseHand();
        return "";
    }

    static string GetComputerHand()
    {
        int randomNumber = new Random().Next(1, 4);
        if (randomNumber == 1)
        {
            return "rock";
        }

        if (randomNumber == 2)
        {
            return "paper";
        }

        if (randomNumber == 3)
        {
            return "scissors";
        }
        ;
        return "";
    }

    static void SaveGame()
    {
        SavePlayerData save = new(Player1Wins, Player2Wins);
        string saveData = JsonSerializer.Serialize(save);
        File.WriteAllText("savePlayersGame.json", saveData);
    }

    static void LoadGame()
    {
        if (!File.Exists("savePlayersGame.json"))
            return;
        string jsonString = File.ReadAllText("savePlayersGame.json");
        SavePlayerData? data = JsonSerializer.Deserialize<SavePlayerData>(jsonString);
        if (data != null)
        {
            Player1Wins = data.Player1Wins;
            Player2Wins = data.Player2Wins;
        }
    }
}

internal class SavePlayerData
{
    public int Player1Wins { get; set; }
    public int Player2Wins { get; set; }

    public SavePlayerData(int player1Wins, int player2Wins)
    {
        Player1Wins = player1Wins;
        Player2Wins = player2Wins;
    }
}
