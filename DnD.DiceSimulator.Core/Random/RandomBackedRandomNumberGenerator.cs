namespace DnD.DiceSimulator.Core.Random
{
    /// <inheritdoc cref="IRandomNumberGenerator"/>
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
