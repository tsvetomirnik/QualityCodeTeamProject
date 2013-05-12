using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public class Bomb : FieldObject
	{
		private Explosion _explosion;

		public Bomb(Cell position, int size, Explosion explosion)
			: base(position, new char[,]{{ (char)size }})
		{
			Explosion = explosion;
		}

		public Explosion Explosion
		{
			get { return _explosion; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Explosion");
				}

				_explosion = value;
			}
		}
	}
}
