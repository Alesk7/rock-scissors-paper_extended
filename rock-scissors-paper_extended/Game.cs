using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissors_paper_extended
{
    class Game
    {
        private const int NumberOfElements = 5;
        public readonly string[] Elements = new string[NumberOfElements]
        { "Paper", "Rock", "Lizzard", "Spock", "Scissors" };

        public readonly int[,] Relationships = new int[NumberOfElements, NumberOfElements / 2]
        { { 1, 3 }, { 2, 4 }, { 3, 0 }, { 4, 1 }, { 0, 2 } };

        private int ComputerChoice;
        private int UserChoice;

        public int GetComputerChoice() { return ComputerChoice; }

        public void GenerateComputerChoice()
        {
            ComputerChoice = new Random().Next(0, NumberOfElements);
            Console.WriteLine("Computer has made choice.");
        }

        public void SetUserChoice(int UserChoice)
        {
            this.UserChoice = UserChoice;
        }

        /// <returns> 0 if nobody wins; 1 if user; -1 if comuter</returns>
        public int CompareChoices()
        {
            if (UserChoice == ComputerChoice) return 0;

            for (int i = 0; i < NumberOfElements / 2; i++)
            {
                if (ComputerChoice == Relationships[UserChoice, i]) return 1;
            }
            
            return -1;
        }

        public void PrintResult(int Result)
        {
            if (Result == 1) Console.WriteLine("\nYou win!\n".ToUpper());
            else if (Result == -1) Console.WriteLine("\nYou lose :(\n".ToUpper());
            else Console.WriteLine("\nDraw.\n".ToUpper());

            Console.WriteLine("User choice: " + Elements[UserChoice]);
            Console.WriteLine("Computer choice: " + Elements[ComputerChoice]);
        }

        public void PrintMenu()
        {
            for (int i = 1; i <= NumberOfElements; i++)
                Console.WriteLine(i + ". " + Elements[i - 1]);
            Console.WriteLine();
        }
    }
}
