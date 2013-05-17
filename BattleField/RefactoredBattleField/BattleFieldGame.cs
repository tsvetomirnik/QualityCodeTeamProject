namespace RefactoredBattleField
{
    using System;
    using System.Linq;
    using RefactoredBattleField.View;

	class BattleFieldGame
	{
        /// <summary>
        /// The entry point of the game.
        /// </summary>
        static void Main(string[] args)
        {
            IUserInput userInput = new ConsoleUserInput();
		    IUserOutput userOutput = new ConsoleUserOutput();
            Controller.GameEngine game = new Controller.GameEngine(userInput, userOutput);
            game.Run();


            // P.S. Git Repository:
            // https://github.com/tsvetomir-nikolov/QualityCodeTeamProject
		}
	}
}