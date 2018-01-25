using System;
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
            Console.WriteLine("rock-scissors-paper extended game".ToUpper());
            while (true)
            {
                game.PrintMenu();
                GenerateHMACKey();
                game.GenerateComputerChoice();
                Console.WriteLine("HMAC: " + GetHMAC(game.Elements[game.GetComputerChoice()]));
                Console.Write("Make your choice: ");
                int Choice = Int32.Parse(Console.ReadLine());
                if (Choice > Game.NumberOfElements || Choice < 1)
                {
                    if (Choice == 0) break;
                    Console.WriteLine("Wrong choice.");
                    continue;
                }
                game.SetUserChoice(Choice - 1);
                game.PrintResult(game.CompareChoices());
                Console.WriteLine("KEY: " + BitConverter.ToString(HMAC.Key).Replace("-", string.Empty));
                Console.WriteLine();
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
