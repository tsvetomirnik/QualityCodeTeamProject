using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public class Explosion : FieldObject
	{
		public Explosion(Cell centerPosition, char[,] body)
			: base (centerPosition, body)
		{
		}
	}
}
