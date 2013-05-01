using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
	public class Field
	{
		private int n;
		private string[,] _field;
		private int izgyrmqniBombi = 0;
		private int countOfNumberedCells = 0;
		private int killedNumbers = 0;

		public void FillInTheFields()
		{
			int row;
			int column;
			while (countOfNumberedCells + 1 <= 0.3 * n * n) 
			{
				row = RandomGenerator.GetRand(0, n - 1);
				column = RandomGenerator.GetRand(0, n - 1);
                
				if (_field[row, column] == "-")
				{
					_field[row, column] = Convert.ToString(RandomGenerator.GetRand(1, 5));
					countOfNumberedCells++;

					if (countOfNumberedCells >= 0.15 * n * n) 
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
			n = ReadCellsNumber();

			_field = new string[n, n];
			for (int i = 0; i <= n - 1; i++)

			for (int j = 0; j <= n - 1; j++)
			{
				_field[i, j] = "-";
			}
		}

		public int ReadCellsNumber()
		{
			string readThings;
			int readNumber;
			do
			{
				Console.Write("Please enter valid size of the field: ");
				readThings = Console.ReadLine();

				if (!(Int32.TryParse(readThings, out readNumber)))
				{
					readNumber = -1;
				}
			}
			while (!(proverka(readNumber)));

			return readNumber;
		}

		public Boolean proverka(int inputNumber) 
		{
			if ((inputNumber < 1) || (inputNumber > 10))
				return false;
			else
				return true;
		}

		public void MineCell(int row, int column)
		{
			int cellNumber;

			if ((_field[row, column] == "X") || ((_field[row, column]) == "-"))
				cellNumber = 0;
			else
				cellNumber = Convert.ToInt32(_field[row, column]);
			switch (cellNumber)
			{
				case 1:
					{
						BombOne(row, column);
						Print();
						izgyrmqniBombi++;
						break;
					}
				case 2:
					{
						BombTwo(row, column);
						Print();
						izgyrmqniBombi++;
						break;
					}
				case 3:
					{
						BombThree(row, column);
						Print();
						izgyrmqniBombi++;
						break;
					}
				case 4:
					{
						BombFour(row, column);
						Print();
						izgyrmqniBombi++;
						break;
					}
				case 5:
					{
						BombFive(row, column);
						Print();
						izgyrmqniBombi++;
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
			killedNumbers++;
			if ((row - 1 >= 0) && (column - 1 >= 0)) 
			{
				if ((_field[row - 1, column - 1] != "X") && (_field[row - 1, column - 1] != "-"))
					killedNumbers++;
				_field[row - 1, column - 1] = "X";
			}

			if ((row + 1 <= n - 1) && (column - 1 >= 0))
			{
				if ((_field[row + 1, column - 1] != "X") && (_field[row + 1, column - 1] != "-"))
					killedNumbers++;
				_field[row + 1, column - 1] = "X";
			}

			if ((row - 1 >= 0) && (column + 1 <= n - 1))
			{
				if ((_field[row - 1, column + 1] != "X") && (_field[row - 1, column + 1] != "-"))
					killedNumbers++;
				_field[row - 1, column + 1] = "X";
			}

			if ((row + 1 <= n - 1) && (column + 1 <= n - 1))
			{
				if ((_field[row + 1, column + 1] != "X") && (_field[row + 1, column + 1] != "-"))
					killedNumbers++;
				_field[row + 1, column + 1] = "X";
			}
		}

		public void BombTwo(int row, int column)
		{
			BombOne(row, column);

			if (row - 1 >= 0)
			{
				if ((_field[row - 1, column] != "X") && (_field[row - 1, column] != "-"))
					killedNumbers++;
				_field[row - 1, column] = "X";
			}

			if (column - 1 >= 0)
			{
				if ((_field[row, column - 1] != "X") && (_field[row, column - 1] != "-"))
					killedNumbers++;
				_field[row, column - 1] = "X";
			}

			if (column + 1 <= n - 1)
			{
				if ((_field[row, column + 1] != "X") && (_field[row, column + 1] != "-"))
					killedNumbers++;
				_field[row, column + 1] = "X";
			}

			if (row + 1 <= n - 1)
			{
				if ((_field[row + 1, column] != "X") && (_field[row + 1, column] != "-"))
					killedNumbers++;
				_field[row + 1, column] = "X";
			}
		}

		public void BombThree(int row, int column)
		{
			BombTwo(row, column);
            
			if (row - 2 >= 0)
			{
				if ((_field[row - 2, column] != "X") && (_field[row - 2, column] != "-"))
					killedNumbers++;
				_field[row - 2, column] = "X";
			}

			if (column - 2 >= 0)
			{
				if ((_field[row, column - 2] != "X") && (_field[row, column - 2] != "-"))
					killedNumbers++;
				_field[row, column - 2] = "X";
			}

			if (column + 2 <= n - 1)
			{
				if ((_field[row, column + 2] != "X") && (_field[row, column + 2] != "-"))
					killedNumbers++;
				_field[row, column + 2] = "X";
			}

			if (row + 2 <= n - 1)
			{
				if ((_field[row + 2, column] != "X") && (_field[row + 2, column] != "-"))
					killedNumbers++;
				_field[row + 2, column] = "X";
			}
		}

		public void BombFour(int row, int column)
		{
			BombThree(row, column);

			if ((row - 1 >= 0) && (column - 2 >= 0))
			{
				if ((_field[row - 1, column - 2] != "X") && (_field[row - 1, column - 2] != "-"))
					killedNumbers++;
				_field[row - 1, column - 2] = "X";
			}

			if ((row + 1 <= n - 1) && (column - 2 >= 0))
			{
				if ((_field[row + 1, column - 2] != "X") && (_field[row + 1, column - 2] != "-"))
					killedNumbers++;
				_field[row + 1, column - 2] = "X";
			}

			if ((row - 2 >= 0) && (column - 1 >= 0))
			{
				if ((_field[row - 2, column - 1] != "X") && (_field[row - 2, column - 1] != "-"))
					killedNumbers++;
				_field[row - 2, column - 1] = "X";
			}

			if ((row + 2 <= n - 1) && (column - 1 >= 0))
			{
				if ((_field[row + 2, column - 1] != "X") && (_field[row + 2, column - 1] != "-"))
					killedNumbers++;
				_field[row + 2, column - 1] = "X";
			}
			//

			if ((row - 1 >= 0) && (column + 2 <= n - 1))
			{
				if ((_field[row - 1, column + 2] != "X") && (_field[row - 1, column + 2] != "-"))
					killedNumbers++;
				_field[row - 1, column + 2] = "X";
			}

			if ((row + 1 <= n - 1) && (column + 2 <= n - 1))
			{
				if ((_field[row + 1, column + 2] != "X") && (_field[row + 1, column + 2] != "-"))
					killedNumbers++;
				_field[row + 1, column + 2] = "X";
			}

			if ((row - 2 >= 0) && (column + 1 <= n - 1))
			{
				if ((_field[row - 2, column + 1] != "X") && (_field[row - 2, column + 1] != "-"))
					killedNumbers++;
				_field[row - 2, column + 1] = "X";
			}

			if ((row + 2 <= n - 1) && (column + 1 <= n - 1))
			{
				if ((_field[row + 2, column + 1] != "X") && (_field[row + 2, column + 1] != "-"))
					killedNumbers++;
				_field[row + 2, column + 1] = "X";
			}
		}

		public void BombFive(int row, int column)
		{
			BombFour(row, column);

			if ((row - 2 >= 0) && (column - 2 >= 0))
			{
				if ((_field[row - 2, column - 2] != "X") && (_field[row - 2, column - 2] != "-"))
					killedNumbers++;
				_field[row - 2, column - 2] = "X";
			}

			if ((row + 2 <= n - 1) && (column - 2 >= 0))
			{
				if ((_field[row + 2, column - 2] != "X") && (_field[row + 2, column - 2] != "-"))
					killedNumbers++;
				_field[row + 2, column - 2] = "X";
			}

			if ((row - 2 >= 0) && (column + 2 <= n - 1))
			{
				if ((_field[row - 2, column + 2] != "X") && (_field[row - 2, column + 2] != "-"))
					killedNumbers++;
				_field[row - 2, column + 2] = "X";
			}

			if ((row + 2 <= n - 1) && (column + 2 <= n - 1))
			{
				if ((_field[row + 2, column + 2] != "X") && (_field[row + 2, column + 2] != "-"))
					killedNumbers++;
				_field[row + 2, column + 2] = "X";
			}
		}

		public void Print()
		{
			Console.Write("   ");
			for (int k = 0; k <= n - 1; k++)
			{
				Console.Write(k + " ");
			}
			Console.WriteLine();
			Console.Write("   ");
			for (int k = 0; k <= n - 1; k++)
			{
				Console.Write("--");
			}
			Console.WriteLine();

			for (int i = 0; i <= n - 1; i++)
			{
				Console.Write(i + "| ");
				for (int j = 0; j <= n - 1; j++)
				{
					Console.Write(_field[i, j] + " ");
				}

				Console.WriteLine();

				Console.WriteLine();
			}
		}

		public bool OutOfAreaCoordinates(int row, int column)
		{
			if ((row >= 0) && (row <= n - 1) && (column >= 0) && (column <= n - 1))
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
			if (killedNumbers == countOfNumberedCells)
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

			Console.WriteLine("Game Over.Detonated Mines {0}", izgyrmqniBombi);
		}

		public string GetValue(Cell cell)
		{
			return _field[cell.Row, cell.Col];
		}
	}
}
