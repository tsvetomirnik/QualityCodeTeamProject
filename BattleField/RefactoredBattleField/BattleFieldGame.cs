using System;
using System.Linq;

namespace RefactoredBattleField
{
	class BattleFieldGame
	{
        /// <summary>
        /// The entry point of the game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Controller.GameEngine game = new Controller.GameEngine();
            game.Run();
		}
	}
}