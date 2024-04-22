using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Sorter = SortingLibrary.Sorter;


namespace Journey.SortTests
{
    [TestClass]
    public class SortTest2
    {
	    List<int> numbers = new List<int> { 5, 4, 1, 3, 2 };

        [TestMethod]
        public void MergeTest1()
        {
            Sorter.MergeSort(numbers);
            Assert.AreEqual(2, numbers[1]);
		}

		[TestMethod]
		public void MergeTest2()
		{
			numbers.Add(-1);
			Sorter.MergeSort(numbers);
			Assert.AreEqual(-1, numbers[0]);
		}

		[TestMethod]
		public void MergeTest3Count()
		{
			numbers.Add(1);
			numbers.Add(2);
			Sorter.MergeSort(numbers);
			Assert.AreEqual(7, numbers.Count);
		}

		[TestMethod]
		public void MergeTest4OneIndex()
		{
			List<int> oneItem = new List<int> { 3 };
			Sorter.MergeSort(oneItem);
			Assert.AreEqual(3, oneItem[0]);
		}

		[TestMethod]
		public void MergeTest5BigArray()
		{
			numbers.AddRange([2, 7, 1, 4, 21, 87, 0, -5, 21, 199]);
			Sorter.MergeSort(numbers);
			Assert.AreEqual(87, numbers[13]);
		}

		[TestMethod]
		public void QuickTest1()
		{
			Sorter.QuickSort(numbers, 0, numbers.Count - 1);
			Assert.AreEqual(3, numbers[2]);
		}

		[TestMethod]
		public void QuickTest2()
		{
			Sorter.QuickSort(numbers, 0, numbers.Count - 1);
			Assert.AreEqual(5, numbers[4]);
		}

		[TestMethod]
		public void QuickTest3Count()
		{
			numbers.Add(1);
			numbers.Add(2);
			Sorter.QuickSort(numbers, 0, numbers.Count - 1);
			Assert.AreEqual(7, numbers.Count);
		}

		[TestMethod]
		public void QuickTest4OneIndex()
		{
			List<int> oneItem = new List<int> { 3 };
			Sorter.QuickSort(oneItem, 0, oneItem.Count - 1);
			Assert.AreEqual(3, oneItem[0]);
		}

		[TestMethod]
		public void QuickTest5BigArray()
		{
			numbers.AddRange([2, 7, 1, 4, 21, 87, 0, -5, 21, 199]);
			Sorter.QuickSort(numbers, 0, numbers.Count - 1);
			Assert.AreEqual(87, numbers[13]);
		}
	}
}
