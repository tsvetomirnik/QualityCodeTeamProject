namespace BattleField
{
    using System;
    using System.Linq;

	public class RandomGenerator
	{
		private static readonly Random random = new Random();

		public static int GetRand(int min, int max)
		{
			return Convert.ToInt32(random.Next(min, max));
		}
	}
}
