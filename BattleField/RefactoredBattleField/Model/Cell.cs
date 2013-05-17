namespace RefactoredBattleField.Model
{
	using System;
	using System.Linq;

	public struct Cell
	{
        private int row;
        private int col;


        public Cell(int row, int col)
		{
            // Assign the fields with default values (otherwise won't compile!)
            this.row = 0;
            this.col = 0;

            // Assign through properties (for possible validation)
            this.Row = row;
            this.Col = col;
		}

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }
	}
}