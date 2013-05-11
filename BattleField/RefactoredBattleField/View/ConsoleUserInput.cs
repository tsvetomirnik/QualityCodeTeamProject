namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	public class ConsoleUserInput : IUserInput
	{
		public int[] GetFieldSize()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public int[] GetCellPosition()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

        public Model.Cell GetUserInputCell()
        {
            Console.Write("Please enter coordinates: ");

            string inputRowAndColumn = Console.ReadLine();
            string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');

            Model.Cell cell = new Model.Cell();

            bool isValidInput = true;
            do
            {
                // TODO: Show as errors/warnings
                if (rowAndColumnSplit.Length <= 0)
                {
                    isValidInput = false;
                    Console.WriteLine("Invalid parameters count.");
                    break;
                }

                int row;
                int col;
                if (!int.TryParse(rowAndColumnSplit[0], out row)
                    || !int.TryParse(rowAndColumnSplit[1], out col))
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

            } while (!isValidInput);

            return cell;
        }
	}
}