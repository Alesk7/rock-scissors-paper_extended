﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissors_paper_extended
{
    class Game
    {
        public const int NumberOfElements = 5;
        public readonly string[] Elements = new string[NumberOfElements]
        { "Paper", "Rock", "Lizzard", "Spock", "Scissors" };
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

        /// <returns> 0 if nobody wins; 1 if user; -1 if computer</returns>
        public int CompareChoices()
        {
            if (UserChoice == ComputerChoice) return 0;
            for (int i = 0; i < NumberOfElements / 2; i++)
            {
                int UserCanBeatElement = (((2 * (i + 1)) + UserChoice) - 1) % NumberOfElements;
                if (ComputerChoice == UserCanBeatElement) return 1;
            }
            return -1;
        }

        public void PrintResult(int Result)
        {
            if (Result == 1) Console.WriteLine("You win!".ToUpper());
            else if (Result == -1) Console.WriteLine("You lose :(".ToUpper());
            else Console.WriteLine("Draw.".ToUpper());
            Console.WriteLine("Computer choice: " + Elements[ComputerChoice]);
        }

        public void PrintMenu()
        {
            for (int i = 1; i <= NumberOfElements; i++)
                Console.WriteLine(i + ". " + Elements[i - 1]);
            Console.WriteLine("0. Exit");
        }
    }
}
