using DnD.DiceSimulator.Core.ClassFeatures.Paladin;
using DnD.DiceSimulator.Core.Random;
using DnD.DiceSimulator.Core.Random.Dice;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceSimulator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            Simulate(host);
        }

        private static void Simulate(IHost host)
        {
            var iterations = 1_000_000;

            SimulateWeapon(iterations, 2, 6, false, "Greatsword", host);
            SimulateWeapon(iterations, 2, 6, true, "Greatsword", host);
            SimulateWeapon(iterations, 1, 12, false, "Greataxe", host);
            SimulateWeapon(iterations, 1, 12, true, "Greataxe", host);
        }

        static void SimulateWeapon(int iterations, int numberOfDice, int dieSides, bool hasGreaterWeaponMaster, string weaponName, IHost host)
        {
            var diceRoller = host.Services.GetService<IDiceRoller>();
            var features = hasGreaterWeaponMaster ? new[] { host.Services.GetService<GreatWeaponFighting>() } : null;
            var results = Enumerable.Range(0, iterations).Select(x => diceRoller.RollDice(numberOfDice, dieSides, features));
            var average = results.Average(x => x.Sum());
            Console.WriteLine($"Average {weaponName} roll {(hasGreaterWeaponMaster ? "with" : "without")} Greater Weapon Master: {average}");

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IRandomNumberGenerator, RandomBackedRandomNumberGenerator>()
                            .AddSingleton<Random>()
                            .AddTransient<IDiceRoller, DiceRoller>()
                            .AddTransient<GreatWeaponFighting>());
        
    }
}
