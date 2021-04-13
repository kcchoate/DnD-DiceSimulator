namespace DnD.DiceSimulator.Core.ClassFeatures
{
    public interface IClassFeature
    {
        /// <summary>
        /// Given an already <paramref name="rolledValue"/>, this method will return a modified value as implemented by the class feature.
        /// </summary>
        /// <param name="rolledValue">The value already rolled.</param>
        /// <param name="diceSides">The number of sides the rolled die had.</param>
        /// <returns>An updated value for the die roll.</returns>
        int ModifyDieRoll(int rolledValue, int diceSides);
    }
}
