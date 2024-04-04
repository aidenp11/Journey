using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Sorter = SortingLibrary.Sorter;
namespace Tests
{
	[TestClass]
	public class Test
	{
		public bool Equal(int i1, int i2)
		{
			return i1 == i2;
		}

		public int Plus(int i1, int i2)
		{
			return i1 + i2;
		}

		public bool Greater(int i1, int i2)
		{
			return i1 > i2;
		}

		[TestMethod]
		public void EqualTest1()
		{
			bool temp = Equal(10, 10);
			Assert.AreEqual(temp, true);
		}

		[TestMethod]
		public void PlusTest()
		{
			int temp = Plus(10, 10);
			Assert.AreEqual(temp, 20);
		}

		[TestMethod]
		public void GreaterTest()
		{
			bool temp = Greater(10, 10);
			Assert.AreEqual(temp, false);
		}

		// ***** sort tests *****

		int[] numbers = { 4, 5, 2, 3, 1 };

		// ***** bubbles *****

		[TestMethod]
		public void BubbleTest1()
		{
			Sorter.BubbleSort(numbers);
			Assert.AreEqual(numbers[0], 1);
		}

		[TestMethod]
		public void BubbleTest2()
		{
			Sorter.BubbleSort(numbers);
			Assert.AreEqual(numbers[1], 2);
		}

		[TestMethod]
		public void BubbleTest3()
		{
			Sorter.BubbleSort(numbers);
			Assert.AreEqual(numbers[2], 3);
		}

		[TestMethod]
		public void BubbleTest4()
		{
			Sorter.BubbleSort(numbers);
			Assert.AreEqual(numbers[3], 4);
		}

		[TestMethod]
		public void BubbleTest5()
		{
			Sorter.BubbleSort(numbers);
			Assert.AreEqual(numbers[4], 5);
		}

		// ***** selections *****

		[TestMethod]
		public void SelectionTest1()
		{
			Sorter.SelectionSort(numbers);
			Assert.AreEqual(numbers[0], 1);
		}

		[TestMethod]
		public void SelectionTest2()
		{
			Sorter.SelectionSort(numbers);
			Assert.AreEqual(numbers[2], 3);
		}

		[TestMethod]
		public void SelectionTest3()
		{
			Sorter.SelectionSort(numbers);
			Assert.AreEqual(numbers[4], 5);
		}

		[TestMethod]
		public void SelectionTest4()
		{
			Sorter.SelectionSort(numbers);
			Assert.AreEqual(numbers[1], 2);
		}

		[TestMethod]
		public void SelectionTest5()
		{
			Sorter.SelectionSort(numbers);
			Assert.AreEqual(numbers[3], 4);
		}

		[TestMethod] 
		public void SelectionTest6()
		{

			Sorter.SelectionSort(numbers);
			Assert.IsTrue(numbers[0] < numbers[1]);
		}

		[TestMethod]
		public void SelectionTest7()
		{

			Sorter.SelectionSort(numbers);
			Assert.IsTrue(numbers[4] > numbers[3]);
		}

		// ***** insertions *****

		[TestMethod]
		public void InsertionTest1()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers[0], 1);
		}

		[TestMethod]
		public void InsertionTest2()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers[2], 3);
		}

		[TestMethod]
		public void InsertionTest3()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers[4], 5);
		}

		[TestMethod]
		public void InsertionTest4()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers[1], 2);
		}

		[TestMethod]
		public void InsertionTest5()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers[3], 4);
		}

		[TestMethod]
		public void InsertionTest6()
		{
			Sorter.InsertionSort(numbers);
			Assert.AreEqual(numbers.Length, 5);
		}

		[TestMethod]
		public void InsertionTest7()
		{
			int[] newn = numbers.Append(-1).ToArray();
			Sorter.InsertionSort(newn);
			Assert.AreEqual(newn[0], -1);
		}

		int[] sizeOne = { 5 };
		[TestMethod]
		public void OneTest()
		{
			Sorter.InsertionSort(sizeOne);
			Assert.AreEqual(sizeOne.Length, 0);
		}
	}
}