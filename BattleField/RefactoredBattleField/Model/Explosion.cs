using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public class Explosion : FieldObject
	{
		public Explosion(Cell position, char[,] body)
			: base (position, body)
		{
		}
	}
}
