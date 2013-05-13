namespace RefactoredBattleField.View
{
	using System;
	using System.Linq;
    using System.Text;

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

        public void DisplayField(Model.Field field)
        {
            const int TopBarOffsetSize = 3;
            // TODO: declare char constants

            StringBuilder topNumbersBar = new StringBuilder();
            topNumbersBar.Append(new string(' ', TopBarOffsetSize));
            for (int k = 0; k <= field.Size - 1; k++)
            {
                topNumbersBar.AppendFormat("{0} ", k);
            }
            topNumbersBar.AppendLine();

            topNumbersBar.Append(new string(' ', TopBarOffsetSize));
            topNumbersBar.AppendLine(new string('-', field.Size * 2)); //TODO: _fieldSize * 2 works only for 0-9 numbers
            Console.WriteLine(topNumbersBar.ToString());

            StringBuilder fieldString = new StringBuilder();
            for (int i = 0; i <= field.Size - 1; i++)
            {
                fieldString.AppendFormat("{0}| ", i);
                for (int j = 0; j <= field.Size - 1; j++)
                {
                    fieldString.AppendFormat("{0} ", field.ToString());   //_field[i, j]
                }

                fieldString.AppendLine();
                fieldString.AppendLine();
            }

            Console.WriteLine(fieldString);
        }
	}
}