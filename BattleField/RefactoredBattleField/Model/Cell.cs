namespace RefactoredBattleField.Model
{
	using System;
	using System.Linq;

	public struct Cell
	{
		private int _row;
		private int _col;

		public Cell(int row, int col)
		{
			_row = row;
			_col = col;
		}

		public int Row
		{
			get
			{
				return _row;
			}
			set
			{
				_row = value;
			}
		}

		public int Col
		{
			get
			{
				return _col;
			}
			set
			{
				_col = value;
			}
		}
	}
}