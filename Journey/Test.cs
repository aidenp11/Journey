using System.Reflection.Metadata.Ecma335;

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
		
		//bubble sort tests
		int[] numbers = { 4, 5, 2, 3, 1 };

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
	}
}