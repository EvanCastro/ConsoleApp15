using ConsoleAppProject.App;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject.App05
{
    /// <summary>
    /// Rock Paper Scissors application
    /// Allows player to choose from Rock, paper and scissors to beat computer
    /// Author:Evan Castro
    /// Version 24/06/2021
    /// </summary>
    public class RPSGame
    {
        private Choice playerFinalChoice = Choice.Underclared;
        private Choice computerFinalChoice = Choice.Underclared;
        private static Random randomGen = new Random(DateTime.Now.Millisecond);

        int userPoints = 0;
        int computerPoints = 0;

        private int x = 20;

        private int y = 50;

        string name;

        /// <summary>
        /// Output heading using the console helper
        /// Ask for the name of the player
        /// Ask how many rounds the player would like to play
        /// Ask player to make their choice.
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("Rock, Paper, Scissors Game");

                Console.WriteLine("Please Input Player's name");
                name = Console.ReadLine();

                Console.WriteLine("How many rounds would you like to play?");
                int rounds = GetDesiredRounds();

                for (var round = 1; round <= rounds; round++)
                {
                    Console.WriteLine("Round {0} Begins", round);
                    Console.WriteLine("Choose between Rock, Paper, Scissor? ");
                    //Allows players to choose by typing Rock,Paper or Scissors
                    var playerChoice = GetPlayerChoice();
                    Console.WriteLine(name + "" + " chose: {0}", playerChoice.ToString());
                    //Allows computer to choose
                    var computerAction = GetComputerChoice();
                    Console.WriteLine("Your opponent chose: {0}", computerAction.ToString());
                    //Dictates the point added to each player
                    switch (CalculateResult(playerChoice, computerAction))
                    {
                        case Result.PlayerWon:
                            Console.WriteLine(name + "" + "won the round! You gained 1 point.\n");
                            GameImages.DrawThumbsUp();
                            userPoints++;
                            break;
                        case Result.CPUWon:
                            Console.WriteLine("Computer won the round! Computer gained 1 point.\n");
                            GameImages.DrawThumbsDown();
                            computerPoints++;
                            break;
                        case Result.Tie:
                            Console.WriteLine("Round tied. You and the computer gained 1 point.\n");
                            userPoints++;
                            computerPoints++;
                            break;
                    }
                    DrawChoice(computerFinalChoice);
                    DrawChoice(playerFinalChoice);
                    Console.WriteLine();

                }
                //Displays the result after all rounds has ended
                Console.WriteLine("Results -Player {0}, Computer {1}", userPoints, computerPoints);
                if (userPoints == computerPoints)
                {
                    Console.WriteLine("Game Draw");
                }
                else
                {
                    bool isPlayerWinner = userPoints > computerPoints;
                    Console.WriteLine("{0} won the game", isPlayerWinner ? "" + name + "" : "Computer");

                }
                repeat = ConsoleHelper.WantToRepeat();
            }
        }
        /// <summary>
        /// reads the desired rounds through user input
        /// puts out error message for non numerical characters
        /// </summary>
        /// <returns></returns>
        public static int GetDesiredRounds()
        {
            int result;
            do
            {
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input a number.");
                }
            } while (true);
        }
        ///reads the player's choices
        ///Throws out an error message if input is not recognised.
        public static Choice GetPlayerChoice()
        {
            Choice result;
            do
            {
                var input = Console.ReadLine();
                if (Choice.TryParse(input, true, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid action {0}. Please input 'Rock', 'Paper' or 'Scissors'.", input);
                }
            } while (true);
        }
        //Uses random generator to choose which hand the computer picks.
        public static Choice GetComputerChoice()
        {
            // Gets a random number between 1 (Action.Rock) and 4 (Action.Scissor + 1)
            // This will result in the values 1 (Rock), 2 (Paper), or 3 (Scissor)
            return (Choice)randomGen.Next((int)Choice.Rock, (int)Choice.Scissors + 1);
        }


        public void DrawChoice(Choice choice)
        {
            ///choices that are offered
            switch (choice)
            {
                case Choice.Rock:
                    GameImages.DrawRock(x, y);
                    break;
                case Choice.Scissors:
                    GameImages.DrawScissors(x, y);
                    break;
                case Choice.Paper:
                    GameImages.DrawPaper(x, y);
                    break;
            }
        }

        ///using switch statement to list the possible outcome
        ///
        public static Result CalculateResult(Choice results, Choice action)
        {
            switch (results)
            {
                case Choice.Rock:
                    switch (action)
                    {
                        case Choice.Rock: return Result.Tie;
                        case Choice.Paper: return Result.CPUWon;
                        case Choice.Scissors: return Result.PlayerWon;
                    }
                    break;
                case Choice.Paper:
                    switch (action)
                    {
                        case Choice.Rock: return Result.PlayerWon;
                        case Choice.Paper: return Result.Tie;
                        case Choice.Scissors: return Result.CPUWon;
                    }
                    break;
                case Choice.Scissors:
                    switch (action)
                    {
                        case Choice.Rock: return Result.CPUWon;
                        case Choice.Paper: return Result.PlayerWon;
                        case Choice.Scissors: return Result.Tie;
                    }
                    break;
            }
            throw new Exception(string.Format("Unhandled action pair occured: {0}, {1}", results, action));
        }
    }
}
