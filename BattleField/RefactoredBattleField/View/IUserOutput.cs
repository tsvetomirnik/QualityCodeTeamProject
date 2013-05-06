namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	public interface IUserOutput
	{
		void DisplayMessage();

		void DisplayWarning();

		void DisplayException();
	}
}