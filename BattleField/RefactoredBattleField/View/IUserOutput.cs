namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	public interface IUserOutput
	{
		void DisplayMessage(string message);

		void DisplayWarning(string message);

		void DisplayException(Exception exception);

        void DisplayField(Model.Field field);
	}
}