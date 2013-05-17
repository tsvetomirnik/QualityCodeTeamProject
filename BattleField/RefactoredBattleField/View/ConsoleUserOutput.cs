namespace RefactoredBattleField.View
{
	using System;
    using System.Text;

    public class ConsoleUserOutput : IUserOutput
	{
		public void DisplayMessage(string message)
		{
			Console.WriteLine(message);
		}

		public void DisplayWarning(string message)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public void DisplayException(Exception exception)
		{
			Console.WriteLine(exception.Message);
		}

        /// <summary>
        /// Displays the field with generated positions.
        /// </summary>
        /// <param name="field">The field.</param>
        public void DisplayField(Model.Field field)
        {
            const int TopBarOffsetSize = 3;
            // TODO: declare char constants

            StringBuilder topNumbersBar = new StringBuilder();
            topNumbersBar.Append(new string(' ', TopBarOffsetSize));
            for (int k = 0; k <= field.Size - 1; k++)
            {
                topNumbersBar.AppendFormat("{0} ", k);
            }
            topNumbersBar.AppendLine();

            topNumbersBar.Append(new string(' ', TopBarOffsetSize));
            topNumbersBar.AppendLine(new string('-', field.Size * 2)); //TODO: _fieldSize * 2 works only for 0-9 numbers
            Console.WriteLine(topNumbersBar.ToString());

            StringBuilder fieldString = new StringBuilder();
            for (int row = 0; row <= field.Size - 1; row++)
            {
                fieldString.AppendFormat("{0}| ", row);
                for (int col = 0; col <= field.Size - 1; col++)
                {
                    var position = new Model.Cell(row, col);
                    fieldString.AppendFormat("{0} ", field.GetSymbolInPosition(position));
                }

                fieldString.AppendLine();
                fieldString.AppendLine();
            }

            Console.WriteLine(fieldString);
        }
        /*
		public void DisplayField(Field field)
		{
			const int TopBarOffsetSize = 3;
			// TODO: declare char constants

			StringBuilder topNumbersBar = new StringBuilder();
			topNumbersBar.Append(new string(' ', TopBarOffsetSize));
			for (int k = 0; k <= field.Size - 1; k++)
			{
				topNumbersBar.AppendFormat("{0} ", k);
			}
			topNumbersBar.AppendLine();
			
			//Works only for 0-9 numbers
			topNumbersBar.Append(new string(' ', TopBarOffsetSize));
			topNumbersBar.AppendLine(new string('-', field.Size * 2));
			Console.WriteLine(topNumbersBar.ToString());

			//field.AddFieldObjects(new Bomb(new Cell(1,2), 2));
			var b = new Bomb(new Cell(3,3), 3);
			field.AddFieldObjects(b.Explosion);

			//field.AddFieldObjects(new Explosion(new Cell(1, 1), new int[,]{{1, 1, 1}, {1, 1, 1}, {1, 1, 1}}));

			char[,] consoleField = new char[field.Size, field.Size];

			//TODO: Print each element position by position

			//Add empty field
			for (int i = 0; i < field.Size; i++)
			{
				for (int j = 0; j < field.Size; j++)
				{
					consoleField[i, j] = '-';
				}
			}

			//Add bombs
			var bombs = field.GetFieldObjects().Where(x => x is Bomb);
			foreach (Bomb bomb in bombs)
			{
				var bombCell = bomb.GetPosition();
				consoleField[bombCell.Row, bombCell.Col] = bomb.Size.ToString()[0];
			}

			//Add explosion
			var explosions = field.GetFieldObjects().Where(x => x is Explosion);
			foreach (Explosion explosion in explosions)
			{
				var position = explosion.GetPosition();

				for (int i = 0; i < explosion.RangeHeight; i++)
				{
					for (int j = 0; j < explosion.RangeWidth; j++)
					{
						int explosionPower = explosion.GetPower(new Cell(i, j));
						if (explosionPower > 0)
						{
							int desiredRow = position.Row + i;
							int desiredCol = position.Col + j;
							consoleField[desiredRow, desiredCol] = 'x';
						}
					}
				}
				
			}
			//Print field
			for (int i = 0; i < field.Size; i++)
			{
				Console.Write(i + "| ");
				for (int j = 0; j < field.Size; j++)
				{
					Console.Write(consoleField[i, j]);
					Console.Write(" ");
				}

				Console.WriteLine();
			}
		}
        */
	}
}