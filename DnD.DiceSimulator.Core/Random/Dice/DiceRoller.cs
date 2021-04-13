using DnD.DiceSimulator.Core.ClassFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.Random.Dice
{
    public class DiceRoller : IDiceRoller
    {
        IRandomNumberGenerator _rng { get; }
        public DiceRoller(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public int RollDie(int sides, IEnumerable<IClassFeature> enabledFeatures)
        {
            if (enabledFeatures is object && enabledFeatures.Any())
            {
                return enabledFeatures.Aggregate(_rng.GetInt(1, sides), (roll, feature) => feature.ModifyDiceRoll(roll, sides));
            }
            return _rng.GetInt(1, sides);
        }

        public IEnumerable<int> RollDice(int numberOfDice, int sides, IEnumerable<IClassFeature> enabledFeatures) =>
            Enumerable.Range(0, numberOfDice).Select(x => RollDie(sides, enabledFeatures));
    }
}
