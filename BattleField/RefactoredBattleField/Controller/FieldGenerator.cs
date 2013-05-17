namespace RefactoredBattleField.Controller
{
    using System;
    using System.Linq;
    using RefactoredBattleField.Extensions;
    using RefactoredBattleField.Model;
    using System.Collections.Generic;

	public static class FieldGenerator
	{
		public const int MinBombsPercentage = 15;
		public const int MaxBombsPercentage = 30;

        /// <summary>
        /// Generates the field.
        /// </summary>
        /// <param name="fieldSize">Valid size of the field (1..10).</param>
        /// <returns>The newly generated <see cref="Field"/>.</returns>
        public static Field GenerateField(int fieldSizeRows, int fieldSizeCols)
        {
            if (fieldSizeRows <= 0 || fieldSizeCols <= 0)
			{
				throw new ArgumentOutOfRangeException("Negative or zero value for field size. The field size must be positive");
			}

            // Generate field and add the bombs
            Field generatedField = new Field(fieldSizeRows);

            // Generate the bomb position list
		    double bombsPercentage = RandomGenerator.GetRand(MinBombsPercentage, MaxBombsPercentage + 1) * 1.0 / 100;
            int numberOfCells = fieldSizeRows * fieldSizeCols;

            int desiredBombCount = (int)(numberOfCells * bombsPercentage);

            List<Cell> listOfPossibleBombPositions = GenerateBombPositionList(desiredBombCount, fieldSizeRows, fieldSizeCols);

            for (int createdBombCount = 0; createdBombCount < listOfPossibleBombPositions.Count; createdBombCount++)
			{
                Cell bombPosition = listOfPossibleBombPositions[createdBombCount];
                var newBomb = GenerateRandomBomb(bombPosition);

                generatedField.AddFieldObjects(newBomb);
			}

			return generatedField;
		}

        /// <summary>
        /// Generates the bomb position list.
        /// </summary>
        /// <param name="desiredBombCount">The desired bomb count.</param>
        /// <param name="fieldSizeRows">The field size rows.</param>
        /// <param name="fieldSizeCols">The field size cols.</param>
        /// <returns>List with DesiredBombCount number of positions.</returns>
        private static List<Cell> GenerateBombPositionList(int desiredBombCount, int fieldSizeRows, int fieldSizeCols)
        {
            var generateAllPositions = new List<Cell>(fieldSizeRows * fieldSizeCols);

            // Generate all possible positions
            for (int row = 0; row < fieldSizeRows; row++)
            {
                for (int col = 0; col < fieldSizeCols; col++)
                {
                    Cell position = new Cell(row, col);
                    generateAllPositions.Add(position);
                }
            }

            generateAllPositions.Shuffle();

            // Pick only first desiredBombCount number of position
            var generatedPositions = generateAllPositions.GetRange(0, desiredBombCount);

            return generatedPositions;
        }

        /// <summary>
        /// Gets the random bomb.
        /// </summary>
        /// <param name="fieldSize">Size of the field.</param>
        /// <returns>Bomb at position from game field.</returns>
        private static Bomb GenerateRandomBomb(Cell position)
        {
			int size = RandomGenerator.GetRand(Bomb.MinSize, Bomb.MaxSize + 1);
			Bomb bomb = new Bomb(position, size);
			return bomb;
		}
	}
}
