namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;

	public class ConsoleUserOutput : IUserOutput
	{
		public void DisplayMessage(string message)
		{
			Console.WriteLine(message);
		}

		public void DisplayWarning(string message)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public void DisplayException(Exception exception)
		{
			Console.WriteLine(exception.Message);
		}
	}
}