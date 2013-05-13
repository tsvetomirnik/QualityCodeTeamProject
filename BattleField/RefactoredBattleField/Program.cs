using System;
using System.Linq;

namespace RefactoredBattleField
{
	class Program
	{
		static void Main(string[] args)
		{
            Controller.GameEngine game = new Controller.GameEngine();
            game.Run();
		}
	}
}