using DnD.DiceSimulator.Core.Random;
using DnD.DiceSimulator.Core.Random.Dice;

namespace DnD.DiceSimulator.Core.ClassFeatures.Paladin
{
    /// <summary>
    /// Represents the 2nd level "Great Weapon Fighting" choice from the Paladin Fighting Style Class Feature
    /// /// </summary>
    public class GreatWeaponFighting : IClassFeature
    {
        IDiceRoller _diceRoller;

        public GreatWeaponFighting(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }

        /// <summary>
        /// If the <paramref name="rolledValue"/> is 1 or 2, the die is re rolled. Otherwise, the provided value is returned.
        /// </summary>
        /// <param name="rolledValue"><inheritdoc/></param>
        /// <param name="diceSides"><inheritdoc/></param>
        /// <returns>A new die roll if <paramref name="rolledValue"/> is 1 or 2, otherwise <paramref name="rolledValue"/></returns>
        public int ModifyDieRoll(int rolledValue, int diceSides) => rolledValue switch
            {
                1 or 2 => _diceRoller.RollDie(6),
                _ => rolledValue
            };
        
    }
}
