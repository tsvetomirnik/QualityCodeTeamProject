using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoredBattleField.Model;

namespace BattleField.Tests.Model
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void TestFieldConstructorWithFieldSize10()
        {
            int fieldSize = 10;
            Field field = new Field(fieldSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFieldConstructorWithFieldSizeNegativeException()
        {
            int fieldSize = -10;
            Field field = new Field(fieldSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFieldConstructorWithFieldSizeMoreThan10Exception()
        {
            int fieldSize = 100;
            Field field = new Field(fieldSize);
        }


    }
}
