using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public abstract class FieldObject
	{
		protected Cell position;

		public FieldObject(Cell position)
		{
			this.position = position;
		}

		public Cell GetPosition()
		{
			return position;
		}
	}
}
