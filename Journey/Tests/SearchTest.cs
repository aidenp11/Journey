using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorter = SortingLibrary.Sorter;

namespace Journey.SearchTests
{
	[TestClass]
    public class SearchTest
    {
		int[] testArr = { 1, 2, 3, 5, 6, 8, 11, 32, 34 };

		[TestMethod]
		public void MiddleValueTest()
		{
			int expected = Sorter.BinarySearch(6, testArr, 0, testArr.Length);
			Assert.AreEqual(expected, 4);
		}

		[TestMethod]
		public void OneLessThanMiddleValueTest()
		{
			int expected = Sorter.BinarySearch(5, testArr, 0, testArr.Length);
			Assert.AreEqual(expected, 3);
		}

		[TestMethod]
		public void EdgeCaseBeginning()
		{
			int expected = Sorter.BinarySearch(1, testArr, 0, testArr.Length);
			Assert.AreEqual(expected, 0);
		}

		[TestMethod]
		public void EdgeCaseEnd()
		{
			int expected = Sorter.BinarySearch(34, testArr, 0, testArr.Length);
			Assert.AreEqual(expected, 8);
		}

		[TestMethod]
		public void NotInArrayTest()
		{
			int expected = Sorter.BinarySearch(-23, testArr, 0, testArr.Length);
			Assert.AreEqual(expected, -1);
		}

		[TestMethod]
		public void OneElementTest()
		{
			int[] one = { 1 };
			int expected = Sorter.BinarySearch(1, one, 0, one.Length);
			Assert.AreEqual(expected, 0);
		}

		[TestMethod]
		public void ZeroElementTest()
		{
			int[] none = { };
			int expected = Sorter.BinarySearch(10, none, 0, none.Length);
			Assert.AreEqual(expected, -1);
		}
	}
}
