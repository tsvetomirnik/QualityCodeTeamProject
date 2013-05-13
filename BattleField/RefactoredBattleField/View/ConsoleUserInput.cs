namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;
	using RefactoredBattleField.Model;

	public class ConsoleUserInput : IUserInput
	{
		public int GetFieldSize()
		{
            string fieldSizeInput;
            int readNumber;
           
            fieldSizeInput = Console.ReadLine();

            if (!(Int32.TryParse(fieldSizeInput, out readNumber)))
            {
                readNumber = -1;
            }           

            return readNumber;
		}

        

		public int[] GetCellPosition()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public Cell GetUserInputCell()
        {
            Console.Write("Please enter coordinates: ");

			string inputRowAndColumn = Console.ReadLine();
			string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');

			Cell cell = new Cell();

			bool isValidInput = true;
			do
			{
				if (rowAndColumnSplit.Length <= 0)
				{
					isValidInput = false;
					Console.WriteLine("Invalid parameters count.");
					break;
				}

				int row;
				int col;
				if (!int.TryParse(rowAndColumnSplit[0], out row) ||
					!int.TryParse(rowAndColumnSplit[1], out col))
				{
					isValidInput = false;
					Console.WriteLine("Not valid parameters values.");
					break;
				}

				if (isValidInput)
				{
					cell.Row = row;
					cell.Col = col;
				}
			}

			while (!isValidInput);
            return cell;
		}
	}
}