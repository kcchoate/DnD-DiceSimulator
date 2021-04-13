using DnD.DiceSimulator.Core.ClassFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.Random.Dice
{
    public interface IDiceRoller
    {
        int RollDie(int sides, IEnumerable<IClassFeature> enabledFeatures);
        IEnumerable<int> RollDice(int numberOfDice, int sides, IEnumerable<IClassFeature> enabledFeatures);
    }
}
