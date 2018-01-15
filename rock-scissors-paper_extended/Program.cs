﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace rock_scissors_paper_extended
{
    class Program
    {
        private static HMACSHA256 HMAC;

        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("rock-scissors-paper extended game\n".ToUpper());

            while (true)
            {
                game.PrintMenu();

                GenerateHMACKey();
                game.GenerateComputerChoice();
                Console.WriteLine("HMAC: " + GetHMAC(game.Elements[game.GetComputerChoice()]) + "\n");

                Console.Write("Make your choice: ");
                int Choice = Int32.Parse(Console.ReadLine());
                game.SetUserChoice(Choice - 1);

                game.PrintResult(game.CompareChoices());
                Console.WriteLine("HMAC: " + GetHMAC(game.Elements[game.GetComputerChoice()]) + "\n");

                Console.Write("Play again? (y/n): ");
                string PlayAgain = Console.ReadLine();
                if (PlayAgain.Equals("n")) break;
                Console.WriteLine("\n");
            }
        }

        static void GenerateHMACKey()
        {
            HMAC = new HMACSHA256();
        }

        static string GetHMAC(string s)
        {
            return BitConverter.ToString(HMAC.ComputeHash(Encoding.UTF8.GetBytes(s)))
                .Replace("-", string.Empty);
        }
    }
}
