using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public abstract class FieldObject
	{
		protected Cell position;
		protected char[,] body;

		public FieldObject(Cell position, char[,] body)
		{
			this.position = position;
			this.body = body;
		}

		public Cell GetPosition()
		{
			return position;
		}

		public char[,] GetImage()
		{
			return body;
		}
	}
}
