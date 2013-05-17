using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoredBattleField.Model;
using RefactoredBattleField.Controller;

namespace BattleField.Tests.Controller
{
    [TestClass]
    public class FieldGeneratorTests
    {
        [TestMethod]
        public void FieldGeneratorTest()
        {
            int fieldSize = 5;
            Field generatedField = new Field(fieldSize);
        }
    }
}
