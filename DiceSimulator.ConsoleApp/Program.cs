using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceSimulator.ConsoleApp
{
    class Program
    {
        static Random _rng { get; } = new Random();

        static void Main(string[] args)
        {
            var iterations = 1_000_000;

            var greatswordResults = Enumerable.Range(0, iterations).Select(x => RollWeapon(2, 6, false));
            Console.WriteLine($"Average Greatsword roll without Greater Weapon Master: {AverageEnumerableEnumerable(greatswordResults)}");

            var greatswordWithFeatResults = Enumerable.Range(0, iterations).Select(x => RollWeapon(2, 6, true));
            Console.WriteLine($"Average Greatsword role with Greater Weapon Master: {AverageEnumerableEnumerable(greatswordWithFeatResults)}");

            var greataxeResults = Enumerable.Range(0, iterations).Select(x => RollWeapon(1, 12, false));
            Console.WriteLine($"Average Greataxe roll without Greater Weapon Master: {AverageEnumerableEnumerable(greataxeResults)}");

            var greatAaxeWithFeatResults = Enumerable.Range(0, iterations).Select(x => RollWeapon(1, 12, true));
            Console.WriteLine($"Average Greataxe roll with Greater Weapon Master: {AverageEnumerableEnumerable(greatAaxeWithFeatResults)}");

        }

        static IEnumerable<int> RollWeapon(int numberOfDice, int diceSides, bool hasGreaterWeaponMaster) =>
            Enumerable.Range(0, numberOfDice).Select(x => RollDie(diceSides, hasGreaterWeaponMaster));

        static int RollDie(int sides, bool hasGreaterWeaponMaster)
        {
            var a = RollDie(sides);
            if (hasGreaterWeaponMaster && a is 1 or 2)
            {
                a = RollDie(sides);
            }
            return a;

            static int RollDie(int sides) => _rng.Next(1, sides + 1);
        }
        
        static double AverageEnumerableEnumerable(IEnumerable<IEnumerable<int>> values) => values.Average(x => x.Sum());
    }
}
