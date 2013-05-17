namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	public interface IUserInput
	{
		int GetFieldSize();

		int[] GetCellPosition();

        Model.Cell GetUserInputCell();
    }
}