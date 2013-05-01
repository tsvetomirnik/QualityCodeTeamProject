using System;
using System.Linq;

namespace BattleField
{
	public struct Cell
	{
		public Cell(int row, int col)
		{
			Row = row;
			Col = col;
		}

		public int Row { get; set; }
		public int Col { get; set; }
	}
}
