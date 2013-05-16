using System;
using System.Linq;
using RefactoredBattleField.Model;

namespace RefactoredBattleField.Controller
{
	public static class FieldGenerator
	{
		public const int MinBombsPercentage = 15;
		public const int MaxBombsPercentage = 30;

		public static Field GenerateField(int fieldSize)
		{
			if (fieldSize <= 0)
			{
				throw new ArgumentException("Invalid null or negative size value.");
			}

			var bombsPercentage = RandomGenerator.GetRand(MinBombsPercentage, MaxBombsPercentage+1);
			int desiredBombs = (fieldSize * fieldSize) * (bombsPercentage / 100);

			Field generatedField = new Field(fieldSize);

			while (generatedField.FieldObjectsCount < desiredBombs)
			{
				var bomb = GetRandomBomb(fieldSize);
				generatedField.AddFieldObjects(bomb);
			}

			return generatedField;
		}

		private static Bomb GetRandomBomb(int fieldSize)
		{
			var position = GetRandomCell(fieldSize);
			int size = RandomGenerator.GetRand(1, 5);
			Bomb bomb = new Bomb(position, size);
			return bomb;
		}

		private static Cell GetRandomCell(int fieldSize)
		{
			Cell cell = new Cell();
			cell.Row = RandomGenerator.GetRand(0, fieldSize - 1);
			cell.Col = RandomGenerator.GetRand(0, fieldSize - 1);
			return cell;
		}
	}
}
