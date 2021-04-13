using DnD.DiceSimulator.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DiceSimulator.Core.ClassFeatures.Paladin
{
    public class GreaterWeaponMaster : IClassFeature
    {
        IRandomNumberGenerator _rng { get; }

        public GreaterWeaponMaster(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public int ModifyDiceRoll(int rolledValue, int diceSides) => rolledValue switch
            {
                1 or 2 => _rng.GetInt(1, diceSides),
                _ => rolledValue
            };
        
    }
}
