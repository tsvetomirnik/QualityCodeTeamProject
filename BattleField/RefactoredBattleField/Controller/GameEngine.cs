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

        #region Properties
            public Field GameField { get; private set; }

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

                this.GameField = FieldGenerator.GenerateField(fieldSize, fieldSize);

                ShowField();

            
                GameLoop();

            
		    }

            private void GameLoop()
            {
                // Note: To break from the game Loop, you can use break; too.
                bool continueGame = true;
                while (continueGame)
                {
                    Cell cellToBlowUp = this.UserInput.GetUserInputCell();

                    var isBomb = this.GameField.ContainsFieldObject(cellToBlowUp);
                    if (isBomb)
                    {
                        var obj = this.GameField.GetFieldObject(cellToBlowUp);
                        var objBomb = obj as Bomb;

                        objBomb.BombExploded += BombExploded;
                    }

                    // End the loop if needed!
                    if (this.GameField.FieldObjectsCount > 0)
                    {
                        break;
                    }
                }

                ShowField();
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

		private void BombExploded(object sender, EventArgs e)
		{
			explodedBombs++;
			//Calculate covered bombs
		}

		private void ShowField()
		{
			this.UserOutput.DisplayField(this.GameField);
		}
	}
}