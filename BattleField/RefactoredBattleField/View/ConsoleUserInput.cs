namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;
	using RefactoredBattleField.Model;

    /// <summary>
    /// Class for user inputs
    /// </summary>
    public class ConsoleUserInput : IUserInput
    {
        /// <summary>
        /// Gets the size of the field.
        /// </summary>
        /// <returns></returns>
        public int GetFieldSize()
        {
            string fieldSizeInput;
            int readNumber;
           
            fieldSizeInput = Console.ReadLine();

            if (!(int.TryParse(fieldSizeInput, out readNumber)))
            {
                throw new InvalidCastException(string.Format("The input {0} was not an integer.", fieldSizeInput));
            }           

            return readNumber;
		}

		public int[] GetCellPosition()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

        /// <summary>
        /// Gets the coordinates for input cell.
        /// </summary>
        /// <returns>Cell</returns>
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