using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public abstract class FieldObject
	{
		public FieldObject(Cell position, char[,] body)
		{
			this.Position = position;
			this.Image = body;
		}

        public Cell Position { get; private set; }

        public char[,] Image { get; private set; }
	}
}
