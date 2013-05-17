namespace RefactoredBattleField.Model
{
    using System;
    using System.Linq;

	public abstract class FieldObject
	{
		public FieldObject(Cell position, char[,] body)
		{
			this.Position = position;
			this.Image = body;
		}

        public FieldObject(Cell position)
        {
            this.Position = position;
        }

        public Cell Position { get; private set; }

        public char[,] Image { get; private set; }
	}
}
