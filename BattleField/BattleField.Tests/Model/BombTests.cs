using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoredBattleField.Model;

namespace BattleField.Tests.Model
{
    [TestClass]
    public class BombTests
    {
        [TestMethod]
        public void TestBombConstructor()
        {
            int bombSize = 2;
            Cell position = new Cell(4,4);            
            Bomb bomb = new Bomb(position, bombSize);
            Assert.IsNotNull(bomb);
        }

        [TestMethod]
        public void TestBombConstructorForCellWithBombSize5()
        {
            int bombSize = 5;
            Cell position = new Cell(4, 4);
            Bomb bomb = new Bomb(position, bombSize);
            Assert.IsNotNull(bomb);
        }

        [TestMethod]
        public void TestBombConstructorFor2x4Cell()
        {
            int bombSize = 1;
            Cell position = new Cell(2, 4);
            Bomb bomb = new Bomb(position, bombSize);
            Assert.IsNotNull(bomb);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBombConstructorForBombSize6()
        {
            int bombSize = 6;
            Cell position = new Cell(2, 4);
            Bomb bomb = new Bomb(position, bombSize);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBombConstructorForBombSize10()
        {
            int bombSize = 10;
            Cell position = new Cell(2, 4);
            Bomb bomb = new Bomb(position, bombSize);
        }

        

    }
}
