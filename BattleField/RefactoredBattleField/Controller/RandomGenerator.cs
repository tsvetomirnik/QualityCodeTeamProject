namespace RefactoredBattleField.Model
{
	using System;
	using System.Linq;

	public class RandomGenerator
	{
		private static readonly Random random = new Random();

        /// <summary>
        /// Gets the random value as a percentage of number of bombs.
        /// </summary>
        /// <param name="min">The min.(15)</param>
        /// <param name="max">The max.(31)</param>
        /// <returns>Integer value</returns>
        public static int GetRand(int min, int max)
        {
			return Convert.ToInt32(random.Next(min, max));
		}
	}
}