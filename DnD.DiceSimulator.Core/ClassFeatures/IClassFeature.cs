using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.ClassFeatures
{
    public interface IClassFeature
    {
        int ModifyDiceRoll(int rolledValue, int diceSides);
    }
}
