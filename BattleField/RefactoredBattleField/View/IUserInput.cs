namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	interface IUserInput
	{
		int GetFieldSize();

		int[] GetCellPosition();
	}
}