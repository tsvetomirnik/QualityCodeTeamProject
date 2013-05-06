using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
	public class Field
	{
		private int _fieldSize;
		private string[,] _field;
		private int _selectedBombs = 0;
		private int _generatedBombsCount = 0;
		private int _coveredBombs = 0;

		public void AddFieldBombs()
		{
			// TODO: Extract method to calculate the desired count of the bombs depending of desired (rand) percentage
			while (_generatedBombsCount + 1 <= 0.3 * _fieldSize * _fieldSize) 
			{
				Cell cell = new Cell();
				cell.Row = RandomGenerator.GetRand(0, _fieldSize - 1);
				cell.Col = RandomGenerator.GetRand(0, _fieldSize - 1);
				
				// TODO: Use getValue method over Field object
				if (_field[cell.Row, cell.Col] == "-")
				{
					_field[cell.Row, cell.Col] = Convert.ToString(RandomGenerator.GetRand(1, 5));
					_generatedBombsCount++;

					if (_generatedBombsCount >= 0.15 * _fieldSize * _fieldSize) 
					{
						int stopFilling = RandomGenerator.GetRand(0, 1);
						if (stopFilling == 1)
						{
							break;
						}
					}
				}
			}
		}

		public void CreateEmptyField()
		{ 
			_fieldSize = ReadFieldSize();

			_field = new string[_fieldSize, _fieldSize];
			for (int i = 0; i <= _fieldSize - 1; i++)
			{
				for (int j = 0; j <= _fieldSize - 1; j++)
				{
					_field[i, j] = "-";
				}
			}
		}

		public int ReadFieldSize()
		{
			string fieldSizeInput;
			int readNumber;
			do
			{
				Console.Write("Please enter valid size of the field: ");
				fieldSizeInput = Console.ReadLine();

				if (!(Int32.TryParse(fieldSizeInput, out readNumber)))
				{
					readNumber = -1;
				}
			}
			while (!(IsValidFieldSize(readNumber)));

			return readNumber;
		}

		public Boolean IsValidFieldSize(int size)
		{
			if ((size < 1) || (size > 10))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void MineCell(int row, int column)
		{
			int cellNumber;

			if ((_field[row, column] == "X") || ((_field[row, column]) == "-"))
			{
				cellNumber = 0;
			}
			else
			{
				cellNumber = Convert.ToInt32(_field[row, column]);
			}
			
			switch (cellNumber)
			{
				case 1:
					{
						BombOne(row, column);
						ShowField();
						_selectedBombs++;
						break;
					}
				case 2:
					{
						BombTwo(row, column);
						ShowField();
						_selectedBombs++;
						break;
					}
				case 3:
					{
						BombThree(row, column);
						ShowField();
						_selectedBombs++;
						break;
					}
				case 4:
					{
						BombFour(row, column);
						ShowField();
						_selectedBombs++;
						break;
					}
				case 5:
					{
						BombFive(row, column);
						ShowField();
						_selectedBombs++;
						break;
					}

				default:
					{
						ShowInvalidMoveMessage();
						break;
					}
			}
		}

		public void BombOne(int row, int column)
		{
			_field[row, column] = "X";
			_coveredBombs++;
			if ((row - 1 >= 0) && (column - 1 >= 0)) 
			{
				if ((_field[row - 1, column - 1] != "X") && (_field[row - 1, column - 1] != "-"))
					_coveredBombs++;
				_field[row - 1, column - 1] = "X";
			}

			if ((row + 1 <= _fieldSize - 1) && (column - 1 >= 0))
			{
				if ((_field[row + 1, column - 1] != "X") && (_field[row + 1, column - 1] != "-"))
					_coveredBombs++;
				_field[row + 1, column - 1] = "X";
			}

			if ((row - 1 >= 0) && (column + 1 <= _fieldSize - 1))
			{
				if ((_field[row - 1, column + 1] != "X") && (_field[row - 1, column + 1] != "-"))
					_coveredBombs++;
				_field[row - 1, column + 1] = "X";
			}

			if ((row + 1 <= _fieldSize - 1) && (column + 1 <= _fieldSize - 1))
			{
				if ((_field[row + 1, column + 1] != "X") && (_field[row + 1, column + 1] != "-"))
					_coveredBombs++;
				_field[row + 1, column + 1] = "X";
			}
		}

		public void BombTwo(int row, int column)
		{
			BombOne(row, column);

			if (row - 1 >= 0)
			{
				if ((_field[row - 1, column] != "X") && (_field[row - 1, column] != "-"))
					_coveredBombs++;
				_field[row - 1, column] = "X";
			}

			if (column - 1 >= 0)
			{
				if ((_field[row, column - 1] != "X") && (_field[row, column - 1] != "-"))
					_coveredBombs++;
				_field[row, column - 1] = "X";
			}

			if (column + 1 <= _fieldSize - 1)
			{
				if ((_field[row, column + 1] != "X") && (_field[row, column + 1] != "-"))
					_coveredBombs++;
				_field[row, column + 1] = "X";
			}

			if (row + 1 <= _fieldSize - 1)
			{
				if ((_field[row + 1, column] != "X") && (_field[row + 1, column] != "-"))
					_coveredBombs++;
				_field[row + 1, column] = "X";
			}
		}

		public void BombThree(int row, int column)
		{
			BombTwo(row, column);
            
			if (row - 2 >= 0)
			{
				if ((_field[row - 2, column] != "X") && (_field[row - 2, column] != "-"))
					_coveredBombs++;
				_field[row - 2, column] = "X";
			}

			if (column - 2 >= 0)
			{
				if ((_field[row, column - 2] != "X") && (_field[row, column - 2] != "-"))
					_coveredBombs++;
				_field[row, column - 2] = "X";
			}

			if (column + 2 <= _fieldSize - 1)
			{
				if ((_field[row, column + 2] != "X") && (_field[row, column + 2] != "-"))
					_coveredBombs++;
				_field[row, column + 2] = "X";
			}

			if (row + 2 <= _fieldSize - 1)
			{
				if ((_field[row + 2, column] != "X") && (_field[row + 2, column] != "-"))
					_coveredBombs++;
				_field[row + 2, column] = "X";
			}
		}

		public void BombFour(int row, int column)
		{
			BombThree(row, column);

			if ((row - 1 >= 0) && (column - 2 >= 0))
			{
				if ((_field[row - 1, column - 2] != "X") && (_field[row - 1, column - 2] != "-"))
					_coveredBombs++;
				_field[row - 1, column - 2] = "X";
			}

			if ((row + 1 <= _fieldSize - 1) && (column - 2 >= 0))
			{
				if ((_field[row + 1, column - 2] != "X") && (_field[row + 1, column - 2] != "-"))
					_coveredBombs++;
				_field[row + 1, column - 2] = "X";
			}

			if ((row - 2 >= 0) && (column - 1 >= 0))
			{
				if ((_field[row - 2, column - 1] != "X") && (_field[row - 2, column - 1] != "-"))
					_coveredBombs++;
				_field[row - 2, column - 1] = "X";
			}

			if ((row + 2 <= _fieldSize - 1) && (column - 1 >= 0))
			{
				if ((_field[row + 2, column - 1] != "X") && (_field[row + 2, column - 1] != "-"))
					_coveredBombs++;
				_field[row + 2, column - 1] = "X";
			}
			//

			if ((row - 1 >= 0) && (column + 2 <= _fieldSize - 1))
			{
				if ((_field[row - 1, column + 2] != "X") && (_field[row - 1, column + 2] != "-"))
					_coveredBombs++;
				_field[row - 1, column + 2] = "X";
			}

			if ((row + 1 <= _fieldSize - 1) && (column + 2 <= _fieldSize - 1))
			{
				if ((_field[row + 1, column + 2] != "X") && (_field[row + 1, column + 2] != "-"))
					_coveredBombs++;
				_field[row + 1, column + 2] = "X";
			}

			if ((row - 2 >= 0) && (column + 1 <= _fieldSize - 1))
			{
				if ((_field[row - 2, column + 1] != "X") && (_field[row - 2, column + 1] != "-"))
					_coveredBombs++;
				_field[row - 2, column + 1] = "X";
			}

			if ((row + 2 <= _fieldSize - 1) && (column + 1 <= _fieldSize - 1))
			{
				if ((_field[row + 2, column + 1] != "X") && (_field[row + 2, column + 1] != "-"))
					_coveredBombs++;
				_field[row + 2, column + 1] = "X";
			}
		}

		public void BombFive(int row, int column)
		{
			BombFour(row, column);

			if ((row - 2 >= 0) && (column - 2 >= 0))
			{
				if ((_field[row - 2, column - 2] != "X") && (_field[row - 2, column - 2] != "-"))
					_coveredBombs++;
				_field[row - 2, column - 2] = "X";
			}

			if ((row + 2 <= _fieldSize - 1) && (column - 2 >= 0))
			{
				if ((_field[row + 2, column - 2] != "X") && (_field[row + 2, column - 2] != "-"))
					_coveredBombs++;
				_field[row + 2, column - 2] = "X";
			}

			if ((row - 2 >= 0) && (column + 2 <= _fieldSize - 1))
			{
				if ((_field[row - 2, column + 2] != "X") && (_field[row - 2, column + 2] != "-"))
					_coveredBombs++;
				_field[row - 2, column + 2] = "X";
			}

			if ((row + 2 <= _fieldSize - 1) && (column + 2 <= _fieldSize - 1))
			{
				if ((_field[row + 2, column + 2] != "X") && (_field[row + 2, column + 2] != "-"))
					_coveredBombs++;
				_field[row + 2, column + 2] = "X";
			}
		}

		public void ShowField()
		{
			const int TopBarOffsetSize = 3;
			// TODO: declare char constants

			StringBuilder topNumbersBar = new StringBuilder();
			topNumbersBar.Append(new string(' ', TopBarOffsetSize));
			for (int k = 0; k <= _fieldSize - 1; k++)
			{
				topNumbersBar.AppendFormat("{0} ", k);
			}
			topNumbersBar.AppendLine();

			topNumbersBar.Append(new string(' ', TopBarOffsetSize));
			topNumbersBar.AppendLine(new string('-', _fieldSize * 2)); //TODO: _fieldSize * 2 works only for 0-9 numbers
			Console.WriteLine(topNumbersBar.ToString());

			StringBuilder fieldString = new StringBuilder();
			for (int i = 0; i <= _fieldSize - 1; i++)
			{
				fieldString.AppendFormat("{0}| ", i);
				for (int j = 0; j <= _fieldSize - 1; j++)
				{
					fieldString.AppendFormat("{0} ", _field[i, j]);
				}

				fieldString.AppendLine();
				fieldString.AppendLine();
			}

			Console.WriteLine(fieldString);
		}

		public bool IsCellInsideField(Cell cell)
		{
			if (cell.Row >= 0
				&& cell.Col >= 0
				&& cell.Row <= _fieldSize - 1
				&& cell.Col <= _fieldSize - 1)
			{
				return true;
			}

			return false;
		}

		public void ShowInvalidMoveMessage()
		{
			Console.WriteLine("Invalid Move!");
			Console.WriteLine();
		}

		public bool IsCompleted()
		{
			if (_coveredBombs == _generatedBombsCount)
			{
				return true;
			}
			else
			{
				return false;
			}
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

		public void GameSession()
		{
			CreateEmptyField();
			AddFieldBombs();
			ShowField();

			while (!IsCompleted())
			{
				Cell cell = GetUserInputCell();

				if (IsCellInsideField(cell)) 
				{
					MineCell(cell.Row, cell.Col);
				}
				else 
				{
					Console.WriteLine("This move is out of area.");	
				}
			}

			Console.WriteLine("Game over. Detonated mines are {0}.", _selectedBombs);
		}

		public string GetValue(Cell cell)
		{
			return _field[cell.Row, cell.Col];
		}
	}
}
