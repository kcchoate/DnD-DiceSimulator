using DnD.DiceSimulator.Core.ClassFeatures;
using System.Collections.Generic;
using System.Linq;

namespace DnD.DiceSimulator.Core.Random.Dice
{
    /// <inheritdoc cref="IDiceRoller"/>
    public class DiceRoller : IDiceRoller
    {
        IRandomNumberGenerator _rng { get; }

        public DiceRoller(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }

        /// <inheritdoc/>
        public int RollDie(int sides, IEnumerable<IClassFeature> enabledFeatures = null)
        {
            if (enabledFeatures is object && enabledFeatures.Any())
            {
                return enabledFeatures.Aggregate(_rng.GetInt(1, sides), (roll, feature) => feature.ModifyDieRoll(roll, sides));
            }
            return _rng.GetInt(1, sides);
        }

        /// <inheritdoc/>
        public IEnumerable<int> RollDice(int numberOfDice, int sides, IEnumerable<IClassFeature> enabledFeatures = null) =>
            Enumerable.Range(0, numberOfDice).Select(x => RollDie(sides, enabledFeatures));
    }
}
