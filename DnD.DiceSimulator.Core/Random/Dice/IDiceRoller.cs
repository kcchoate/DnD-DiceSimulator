using DnD.DiceSimulator.Core.ClassFeatures;
using System.Collections.Generic;

namespace DnD.DiceSimulator.Core.Random.Dice
{
    /// <summary>
    /// Provides an abstraction for rolling dice, optionally modified by <see cref="IClassFeature"/>s.
    /// </summary>
    public interface IDiceRoller
    {
        /// <summary>
        /// Rolls a single die with n <paramref name="sides"/>, and modifies the results using the provided <paramref name="enabledFeatures"/>.
        /// </summary>
        /// <param name="sides">The number of sides the die has</param>
        /// <param name="enabledFeatures">a collection of class features to modify the dice roll with.</param>
        /// <returns>A value representing the random dice roll modifed by any <paramref name="enabledFeatures"/>.</returns>
        int RollDie(int sides, IEnumerable<IClassFeature> enabledFeatures = null);

        /// <summary>
        /// Rolls <paramref name="numberOfDice"/> dice each with n <paramref name="sides"/>, and modifies the results of each roll using the provided <paramref name="enabledFeatures"/>.
        /// </summary>
        /// <param name="numberOfDice">The number of dice to roll.</param>
        /// <param name="sides">The number of sides the die has.</param>
        /// <param name="enabledFeatures">a collection of class features to modify the dice roll with.</param>
        /// <returns>A collection of <paramref name="numberOfDice"/> values representing the random dice rolls modifed by any <paramref name="enabledFeatures"/>.</returns>
        IEnumerable<int> RollDice(int numberOfDice, int sides, IEnumerable<IClassFeature> enabledFeatures = null);
    }
}
