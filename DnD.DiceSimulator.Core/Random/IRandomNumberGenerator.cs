using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.Random
{
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Generates a random number between <paramref name="minimumValue"/> and <paramref name="maximumValue"/>, inclusive of both values.
        /// </summary>
        /// <param name="minimumValue">The smallest possible value to be returned.</param>
        /// <param name="maximumValue">The largest possiblke value to be returned.</param>
        /// <returns>The generated random number.</returns>
        int GetInt(int minimumValue, int maximumValue);
    }
}
