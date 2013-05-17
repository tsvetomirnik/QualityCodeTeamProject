namespace RefactoredBattleField.Controller
{
    #region Usings
    using System;
    using System.Linq;
    using RefactoredBattleField.Model;
    using RefactoredBattleField.View;
    #endregion

    public class GameEngine
    {
        #region Fields
            private IUserInput userInput;
		    private IUserOutput userOutput;
		    private int coveredBombs = 0;
		    private int explodedBombs = 0;
        #endregion

        #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="GameEngine" /> class.
            /// </summary>
            /// <param name="userInput">The user input.</param>
            /// <param name="userOutput">The user output.</param>
            public GameEngine(IUserInput userInput, IUserOutput userOutput)
            {
                this.userInput = userInput;
                this.userOutput = userOutput;
		    }
        #endregion

        #region GameLoop
            public void Run()
		    {
			
			    Console.WriteLine("Please enter valid size of the field: ");
			    int fieldSize = ReadFieldSize();

			

			    Field field = FieldGenerator.GenerateField(fieldSize);

			    ShowField(field); //TODO: UserOuput shoud do that

            
                GameLoop();

            
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
        #endregion
        

        /// <summary>
        /// A method for check valid field size of the game (1..10).
        /// </summary>
        /// <returns>Return valid field size.</returns>
        public int ReadFieldSize()
        {
            int inputNumber = this.userInput.GetFieldSize();

			return inputNumber ;
		}

		private void BombsExploded(object sender, EventArgs e)
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