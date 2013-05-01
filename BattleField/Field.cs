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

		public void FillInTheFields()
		{
			int row;
			int column;
			while (_generatedBombsCount + 1 <= 0.3 * _fieldSize * _fieldSize) 
			{
				row = RandomGenerator.GetRand(0, _fieldSize - 1);
				column = RandomGenerator.GetRand(0, _fieldSize - 1);

				if (_field[row, column] == "-")
				{
					_field[row, column] = Convert.ToString(RandomGenerator.GetRand(1, 5));
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

		public void CreateBattleTable()
		{ 
			_fieldSize = ReadFieldSize();

			_field = new string[_fieldSize, _fieldSize];
			for (int i = 0; i <= _fieldSize - 1; i++)

			for (int j = 0; j <= _fieldSize - 1; j++)
			{
				_field[i, j] = "-";
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
						Print();
						_selectedBombs++;
						break;
					}
				case 2:
					{
						BombTwo(row, column);
						Print();
						_selectedBombs++;
						break;
					}
				case 3:
					{
						BombThree(row, column);
						Print();
						_selectedBombs++;
						break;
					}
				case 4:
					{
						BombFour(row, column);
						Print();
						_selectedBombs++;
						break;
					}
				case 5:
					{
						BombFive(row, column);
						Print();
						_selectedBombs++;
						break;
					}

				default:
					{
						InvalidMove();
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

		public void Print()
		{
			Console.Write("   ");
			for (int k = 0; k <= _fieldSize - 1; k++)
			{
				Console.Write(k + " ");
			}
			Console.WriteLine();
			Console.Write("   ");
			for (int k = 0; k <= _fieldSize - 1; k++)
			{
				Console.Write("--");
			}
			Console.WriteLine();

			for (int i = 0; i <= _fieldSize - 1; i++)
			{
				Console.Write(i + "| ");
				for (int j = 0; j <= _fieldSize - 1; j++)
				{
					Console.Write(_field[i, j] + " ");
				}

				Console.WriteLine();

				Console.WriteLine();
			}
		}

		public bool OutOfAreaCoordinates(int row, int column)
		{
			if ((row >= 0) && (row <= _fieldSize - 1) && (column >= 0) && (column <= _fieldSize - 1))
			{
				return false;
			}
			return true;
		}

		public void InvalidMove()
		{
			Console.WriteLine("Invalid Move!");
			Console.WriteLine();
		}

		public bool Over()
		{
			if (_coveredBombs == _generatedBombsCount)
				return true;
			else
				return false;
		}

		public void GameSession()
		{
			CreateBattleTable();
			FillInTheFields();
			Print();

			while (!(Over()))
			{
				Console.Write("Please Enter Coordinates : ");

				string inputRowAndColumn = Console.ReadLine();
				string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');
				int row ;
				int column;

				if ((rowAndColumnSplit.Length) <= 0)
				{
					row = - 1;
					column = -1;
				}
				else
				{
					if (!(int.TryParse(rowAndColumnSplit[0], out row)))
						row = -1;
					if (!(int.TryParse(rowAndColumnSplit[1], out column)))
						column = -1;
				}

				if ((OutOfAreaCoordinates(row, column))) 
				{
					Console.WriteLine("This Move Is Out Of Area.");
				}
				else 
				{ 
					MineCell(row, column);
				}
			}

			Console.WriteLine("Game Over.Detonated Mines {0}", _selectedBombs);
		}

		public string GetValue(Cell cell)
		{
			return _field[cell.Row, cell.Col];
		}
	}
}
