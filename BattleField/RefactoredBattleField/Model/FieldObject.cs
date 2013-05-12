using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public abstract class FieldObject
	{
		protected char[,] body;
		protected Cell position;

		public FieldObject(Cell position, char[,] body)
		{
			this.body = body;
			this.position = position;
		}
	}
}
