using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.Random
{
    public class RandomBackedRandomNumberGenerator: IRandomNumberGenerator
    {
        System.Random _random { get; }
        public RandomBackedRandomNumberGenerator(System.Random random)
        {
            _random = random;
        }

        /// <inheritdoc/>
        public int GetInt(int minimumValue, int maximumValue) => _random.Next(minimumValue, maximumValue + 1);
    }
}
