using System;
using System.Linq;
using RefactoredBattleField.Model;

namespace RefactoredBattleField.Controller
{
	public static class FieldGenerator
	{
		public const int MinBombsPercentage = 15;
		public const int MaxBombsPercentage = 30;

        /// <summary>
        /// Generates the field.
        /// </summary>
        /// <param name="fieldSize">Valid size of the field (1..10).</param>
        /// <returns>Field.</returns>
        public static Field GenerateField(int fieldSize)
        {
			if (fieldSize <= 0)
			{
				throw new ArgumentOutOfRangeException("Negative or zero value for field size. The field size must be positive");
			}

		    double bombsPercentage = RandomGenerator.GetRand(MinBombsPercentage, MaxBombsPercentage + 1) * 1.0 / 100;
            int numberOfCells = fieldSize * fieldSize;

            int desiredBombs = (int)(numberOfCells * bombsPercentage);

			Field generatedField = new Field(fieldSize);

			while (generatedField.FieldObjectsCount < desiredBombs)
			{
				var bomb = GetRandomBomb(fieldSize);

                generatedField.AddFieldObjects(bomb);

				//generatedField.AddFieldObjects(bomb);

			}

			return generatedField;
		}

        /// <summary>
        /// Gets the random bomb.
        /// </summary>
        /// <param name="fieldSize">Size of the field.</param>
        /// <returns>Bomb at position from game field.</returns>
        private static Bomb GetRandomBomb(int fieldSize)
        {
			var position = GetRandomCell(fieldSize);
			int size = RandomGenerator.GetRand(1, 5);
			Bomb bomb = new Bomb(position, size);
			return bomb;
		}

        /// <summary>
        /// Gets the random cell.
        /// </summary>
        /// <param name="fieldSize">Size of the field.</param>
        /// <returns>Random cell</returns>
        private static Cell GetRandomCell(int fieldSize)
        {
			Cell cell = new Cell();
			cell.Row = RandomGenerator.GetRand(0, fieldSize - 1);
			cell.Col = RandomGenerator.GetRand(0, fieldSize - 1);
			return cell;
		}
	}
}
