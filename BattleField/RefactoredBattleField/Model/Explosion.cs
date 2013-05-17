namespace RefactoredBattleField.Model
{
    using System;
    using System.Linq;

	public class Explosion : FieldObject
	{
		private int[,] _body;

		public Explosion(Cell coordinates, int[,] body)
			: base (coordinates)
		{
			//TODO: In field must check for out of the field
			_body = body;
		}

		public int[,] Body
		{
			get { return _body; }
		}

		public int GetPower(Cell explosionPosition)
		{
			//TODO: Validate
			return _body[explosionPosition.Row, explosionPosition.Col];
		}

		public int RangeHeight
		{
			get { return _body.GetLength(0); }
		}

		public int RangeWidth
		{
			get { return _body.GetLength(1); }
		}
	}
}
