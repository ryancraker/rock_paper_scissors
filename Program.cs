// using System.Text.Json;

// internal class Program
// {
//     static int PlayerWins = 0;
//     static int ComputerWins = 0;

//     public static void Main()
//     {
//         LoadGame();
//         Console.WriteLine("Rock, Paper, Scissors");
//         Console.WriteLine($"Player at {PlayerWins} wins");
//         Console.WriteLine($"Computer at {ComputerWins} wins");
//         string userHand = ChooseHand();
//         string computerHand = GetComputerHand();
//         Console.WriteLine($"You have selected {userHand}.");
//         Console.WriteLine($"The computer has selected {computerHand}.");
//         if (userHand == computerHand)
//         {
//             Console.WriteLine("You tied!");
//         }
//         else if (userHand == "rock" && computerHand == "paper")
//         {
//             Console.WriteLine("You lose!");
//             ComputerWins++;
//         }
//         else if (userHand == "paper" && computerHand == "scissors")
//         {
//             Console.WriteLine("You lose!");
//             ComputerWins++;
//         }
//         else if (userHand == "scissors" && computerHand == "rock")
//         {
//             Console.WriteLine("You lose!");
//             ComputerWins++;
//         }
//         else if (computerHand == "rock" && userHand == "paper")
//         {
//             Console.WriteLine("You win!");
//             PlayerWins++;
//         }
//         else if (computerHand == "paper" && userHand == "scissors")
//         {
//             Console.WriteLine("You win!");
//             PlayerWins++;
//         }
//         else if (computerHand == "scissors" && userHand == "rock")
//         {
//             Console.WriteLine("You win!");
//             PlayerWins++;
//         }
//         SaveGame();
//         Console.WriteLine($"Player at {PlayerWins} wins");
//         Console.WriteLine($"Computer at {ComputerWins} wins");
//         Console.Write("Play again? y/n");
//         char consoleInput = Console.ReadKey(true).KeyChar;
//         Console.WriteLine();
//         if (consoleInput == 'n')
//         {
//             if (PlayerWins == ComputerWins)
//             {
//                 Console.WriteLine("No winners to be found here");
//             }
//             if (PlayerWins > ComputerWins)
//             {
//                 Console.WriteLine(
//                     "You beat the computer! Now call your parents and tell them the good news."
//                 );
//             }
//             if (ComputerWins > PlayerWins)
//             {
//                 Console.WriteLine(
//                     "You got beat by the computer. Not so smart now are you, smart guy?"
//                 );
//             }
//             return;
//         }
//         Console.Clear();
//         Main();
//     }

//     static string ChooseHand()
//     {
//         Console.WriteLine("Choose a Hand");
//         Console.WriteLine("1. Rock");
//         Console.WriteLine("2. Paper");
//         Console.WriteLine("3. Scissors");

//         char? userInput = Console.ReadKey(true).KeyChar;

//         if (userInput == '1')
//         {
//             return "rock";
//         }
//         else if (userInput == '2')
//         {
//             return "paper";
//         }
//         else if (userInput == '3')
//         {
//             return "scissors";
//         }

//         Console.WriteLine("Invalid selection. Please select a hand");
//         ChooseHand();
//         return "";
//     }

//     static string GetComputerHand()
//     {
//         int randomNumber = new Random().Next(1, 4);
//         if (randomNumber == 1)
//         {
//             return "rock";
//         }

//         if (randomNumber == 2)
//         {
//             return "paper";
//         }

//         if (randomNumber == 3)
//         {
//             return "scissors";
//         }
//         ;
//         return "";
//     }
//     static void SaveGame()
//     {
//         SaveData save = new(PlayerWins, ComputerWins);
//         string saveData = JsonSerializer.Serialize(save);
//         File.WriteAllText("saveGame.json", saveData);
//     }
//     static void LoadGame()
//     {
//         if (!File.Exists("saveGame.json")) return;
//         string jsonString = File.ReadAllText("saveGame.json");
//         SaveData? data = JsonSerializer.Deserialize<SaveData>(jsonString);
//         if (data != null)
//         {
//             PlayerWins = data.PlayerWins;
//             ComputerWins = data.ComputerWins;
//         }
//     }
// }
// internal class SaveData
// {
//     public int PlayerWins { get; set; }
//     public int ComputerWins{ get; set; }
//     public SaveData(int playerWins, int computerWins)
//     {
//         PlayerWins = playerWins;
//         ComputerWins = computerWins;
//     }
// }
