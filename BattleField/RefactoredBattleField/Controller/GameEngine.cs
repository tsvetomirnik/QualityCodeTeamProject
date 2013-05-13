using System;
using System.Linq;
using RefactoredBattleField.Model;
using RefactoredBattleField.View;

namespace RefactoredBattleField.Controller
{
	public class GameEngine
	{
		private readonly IUserInput _userInput;
		private readonly IUserOutput _userOutput;

		int coveredBombs = 0;
		int explodedBombs = 0;

		public GameEngine()
		{
			_userInput = new ConsoleUserInput();
			_userOutput = new ConsoleUserOutput();
		}

		public void Run()
		{
			_userOutput.DisplayMessage("Please enter valid size of the field: ");
			int fieldSize = _userInput.GetFieldSize();
            
            //IRenderer renderer = new ConsoleRenderer(fieldSize);

			Field field = FieldGenerator.GenerateField(fieldSize);

			ShowField(field); //TODO: UserOuput shoud do that

            


			//Just example
			Bomb b = new Bomb(new Cell(1,2), 1);
			b.BombExploded += b_BombExploded;

			//Attach all bombs to BombExplodedEvent

			//...
			//do{
			//
			//	some logic
			//
			//while()
		}

		private void b_BombExploded(object sender, EventArgs e)
		{
			explodedBombs++;
			//Calculate covered bombs
			//ShowField();
		}

		private void ShowField(Field field)
		{
            _userOutput.DisplayField(field);
			//TODO: UserOuput shoud do that
		}
	}
}
