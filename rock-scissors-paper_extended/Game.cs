﻿using System;
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
        { "Paper", "Rock", "Lizzard", "Spock", "Scissors"};

        private int ComputerChoice;
        private int UserChoice;

        public int GetComputerChoice() { return ComputerChoice; }

        public void GenerateComputerChoice()
        {
            ComputerChoice = new Random().Next(0, NumberOfElements);
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
                int UserCanBeatElement = (((2 * (i + 1)) + UserChoice) - 1) % NumberOfElements;
                if (ComputerChoice == UserCanBeatElement) return 1;
            }
            
            return -1;
        }

        public void PrintChoices()
        {
            Console.WriteLine("User choice: " + Elements[UserChoice]);
            Console.WriteLine("Computer choice: " + Elements[ComputerChoice]);
        }

        public void PrintMenu()
        {
            for (int i = 1; i <= NumberOfElements; i++)
                Console.WriteLine(i + ". " + Elements[i - 1]);
            Console.WriteLine("0. Exit\n");
        }
    }
}