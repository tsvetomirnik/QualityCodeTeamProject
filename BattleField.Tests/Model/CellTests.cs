using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoredBattleField.Model;

namespace BattleField.Tests.Model
{
	[TestClass]
	public class CellTests
	{
		[TestMethod]
		public void TestCellConstructorRowParameter()
		{
			const int ExpectedRow = 1;
			Cell cell = new Cell(ExpectedRow, 0);

			Assert.AreEqual(ExpectedRow, cell.Row);
		}

		[TestMethod]
		public void TestCellConstructorColParameter()
		{
			const int ExpectedCol = 1;
			Cell cell = new Cell(0, ExpectedCol);

			Assert.AreEqual(ExpectedCol, cell.Col);
		}

		[TestMethod]
		public void TestCellConstructorRowParameterWithNegativeValue()
		{
			const int ExpectedRow = -1;
			Cell cell = new Cell(ExpectedRow, 0);

			Assert.AreEqual(ExpectedRow, cell.Row);
		}

		[TestMethod]
		public void TestCellConstructorColParameterWithNegativeValue()
		{
			const int ExpectedCol = -1;
			Cell cell = new Cell(0, ExpectedCol);

			Assert.AreEqual(ExpectedCol, cell.Col);
		}

		[TestMethod]
		public void TestCellRowPropertyWithPositiveNumber()
		{
			const int ExpectedRow = 1;
			Cell cell = new Cell(0, 0);
			cell.Row = ExpectedRow;

			Assert.AreEqual(ExpectedRow, cell.Row);
		}

		[TestMethod]
		public void TestCellColPropertyPositiveNumber()
		{
			const int ExpectedCol = 1;
			Cell cell = new Cell(0, 0);
			cell.Col = ExpectedCol;

			Assert.AreEqual(ExpectedCol, cell.Col);
		}

		[TestMethod]
		public void TestCellRowPropertyWithNegativeNumber()
		{
			const int ExpectedRow = -1;
			Cell cell = new Cell(0, 0);
			cell.Row = ExpectedRow;

			Assert.AreEqual(ExpectedRow, cell.Row);
		}

		[TestMethod]
		public void TestCellColPropertyNegativeNumber()
		{
			const int ExpectedCol = -1;
			Cell cell = new Cell(0, 0);
			cell.Col = ExpectedCol;

			Assert.AreEqual(ExpectedCol, cell.Col);
		}
	}
}
