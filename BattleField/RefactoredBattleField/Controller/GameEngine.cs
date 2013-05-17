namespace RefactoredBattleField.Controller
{
    using System;
    using System.Linq;
    using RefactoredBattleField.Model;
    using RefactoredBattleField.View;

	public class GameEngine
	{
		private IUserInput userInput;
		private IUserOutput userOutput;
		int coveredBombs = 0;
		int explodedBombs = 0;

        public GameEngine(IUserInput userInput, IUserOutput userOutput)
		{
            this.userInput = userInput;
            this.userOutput = userOutput;
		}

		public void Run()
		{
			//_userOutput.DisplayMessage("Please enter valid size of the field: ");
			//int fieldSize = _userInput.GetFieldSize();
			Console.WriteLine("Please enter valid size of the field: ");
			int fieldSize = ReadFieldSize();

			//IRenderer renderer = new ConsoleRenderer(fieldSize);

			Field field = FieldGenerator.GenerateField(fieldSize);

			ShowField(field); //TODO: UserOuput shoud do that

            //Game Loop
            GameLoop();

            /*
			//Just example
			Bomb b = new Bomb(new Cell(1,2), 1);
			b.BombExploded += b_BombExploded;
            */
			//Attach all bombs to BombExplodedEvent
			//...
			//do{
			//
			//	some logic
			//
			//while()
		}

        private void GameLoop()
        {
            // Note: To break from the game Loop, you can use break; too.
            bool continueGame = true;
            while (continueGame)
            {
                Cell cellToBlowUp = this.UserInput.GetUserInputCell();

                // Break for now
                break;
            }
        }



        /// <summary>
        /// A method for check valid field size of the game (1..10).
        /// </summary>
        /// <returns>Return valid field size.</returns>
        public int ReadFieldSize()
        {
			string fieldSizeInput;
			int inputNumber;
			do
			{
				fieldSizeInput = Console.ReadLine();
				if (!(Int32.TryParse(fieldSizeInput, out inputNumber)))
				{
					Console.Write("Please enter valid size of the field: ");
				}
			}
			while (inputNumber <= 0 || inputNumber > Field.MaxSize);

			return inputNumber ;
		}

		private void b_BombExploded(object sender, EventArgs e)
		{
			explodedBombs++;
			//Calculate covered bombs
			//ShowField();
		}

		private void ShowField(Field field)
		{
			this.UserOutput.DisplayField(field);
		}

        public IUserInput UserInput
        {
            get
            {
                return this.userInput;
            }
        }
        public IUserOutput UserOutput
        {
            get
            {
                return this.userOutput;
            }
        }
	}
}