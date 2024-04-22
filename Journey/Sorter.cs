using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SortingLibrary
{
	public class Sorter
	{
		public static void BubbleSort(int[] numbers)
		{
			int theNumber = 0;
			int moved = 0;
			do
			{
				moved = 0;
				for (int i = 0; i < numbers.Length - 1; i++)
				{
					if (numbers[i] > numbers[i + 1])
					{
						theNumber = numbers[i];
						numbers[i] = numbers[i + 1];
						numbers[i + 1] = theNumber;
						moved++;
					}
				}
			} while (moved > 0);
		}

		// BIG O = n^2 as well, this is because it is, again, a loop within a loop
		public static void SelectionSort(int[] numbers)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				int selected = i;

				for (int o = i + 1; o < numbers.Length; o++)
				{
					if (numbers[selected] > numbers[o])
					{
						int og = numbers[selected];
						numbers[selected] = numbers[o];
						numbers[o] = og;
						o--;

					}
				}
			}
		}

		// BIG O = n^2, this is because this sort iterates through two loops, a loop in a loop, if you will, so the bigger the array 
		// the longer and longer this method goes on
		public static void InsertionSort(int[] numbers)
		{
			for (int i = 1; i < numbers.Length; i++)
			{
				int inserted = i;
				for (int o = i; o > -1; o--)
				{
					if (numbers[inserted] < numbers[o])
					{
						int og = numbers[o];
						numbers[o] = numbers[inserted];
						numbers[inserted] = og;
						inserted--;
					}
				}
			}
		}

		public static int BinarySearch(int searchVal, int[] listofStuffs, int rangeFront, int rangeBack)
		{
			if (rangeFront == rangeBack)
			{
				return -1;
			}
			int middleValueIndex = (rangeBack + rangeFront) / 2;
			int middleValue = listofStuffs[middleValueIndex];
			if (middleValue == searchVal)
			{
				return middleValueIndex;
			}
			else if (middleValue > searchVal)
			{
				return BinarySearch(searchVal, listofStuffs, rangeFront, middleValueIndex);
			}
			else
			{
				return BinarySearch(searchVal, listofStuffs, middleValueIndex, rangeBack);
			}
		}

		public static void MergeSort(List<int> numbers)
		{
			List<int> firstHalf = new List<int>();
			List<int> secondHalf = new List<int>();

			for (int i = 0; i < numbers.Count / 2; i++)
			{
				firstHalf.Add(numbers[i]);
				if (firstHalf.Count == numbers.Count / 2 && firstHalf.Count != 1)
				{
					MergeSort(firstHalf);
				}
			}

			for (int o = numbers.Count / 2; o < numbers.Count; o++)
			{
				secondHalf.Add(numbers[o]);
				if (secondHalf.Count == numbers.Count - (numbers.Count / 2) && secondHalf.Count != 1)
				{
					MergeSort(secondHalf);
				}
			}

			int[] newNums = Merge(firstHalf, secondHalf);
			for (int y = 0; y < newNums.Length; y++)
			{
				numbers[y] = (newNums[y]);
			}
		}

		public static int[] Merge(List<int> firstArr, List<int> secondArr)
		{
			List<int> newArr = new List<int>();
			int count = firstArr.Count + secondArr.Count;
			int compNum1 = 0;
			int compNum2 = 0;
			for (int i = 0; i < count; i++)
			{
				if (firstArr.Count == 0 && secondArr.Count == 0)
				{
					continue;
				}
				else if (firstArr.Count == 0 && secondArr.Count > 0)
				{
					for (int o = 0; o < secondArr.Count; o++)
					{
						newArr.Add(secondArr.ElementAt(0));
						secondArr.RemoveAt(0);
					}
				}
				else if (firstArr.Count > 0 && secondArr.Count == 0)
				{
					for (int p = 0; p < firstArr.Count; p++)
					{
						newArr.Add(firstArr.ElementAt(p));
						firstArr.RemoveAt(0);
					}
				}
				else
				{
					if (firstArr.ElementAt(compNum1) < secondArr.ElementAt(compNum2))
					{
						newArr.Add(firstArr.ElementAt(compNum1));
						firstArr.RemoveAt(0);

					}
					else
					{
						newArr.Add(secondArr.ElementAt(compNum2));
						secondArr.RemoveAt(0);

					}
				}

			}
			return newArr.ToArray();
		}

		public static void QuickSort(List<int> numbers, int frontIndex, int backIndex)
		{
			if (backIndex > frontIndex)
			{
				int middleIndex = (frontIndex + backIndex) / 2;
				if (numbers[frontIndex] > numbers[middleIndex])
				{
					Swap(frontIndex, middleIndex, numbers);
				}
				if (numbers[backIndex] < numbers[middleIndex])
				{
					Swap(backIndex, middleIndex, numbers);
				}
				if (numbers[frontIndex] > numbers[middleIndex])
				{
					Swap(frontIndex, middleIndex, numbers);
				}
				int pivot = Splinter(numbers, frontIndex, middleIndex, backIndex);
				QuickSort(numbers, frontIndex, pivot - 1);
				QuickSort(numbers, pivot + 1, backIndex);
			}




		}

		public static int Splinter(List<int> numbers, int frontIndex, int pivotIndex, int backIndex)
		{
			bool swapMade;
			for (int i = frontIndex; i < pivotIndex; i++)
			{
				swapMade = false;
				if (numbers[i] > numbers[pivotIndex])
				{
					for (int o = backIndex; o > pivotIndex; o--)
					{
						if (numbers[o] < numbers[pivotIndex])
						{
							Swap(i, o, numbers);
							swapMade = true;
							break;
						}
					}
					if (!swapMade)
					{
						Swap(pivotIndex, i, numbers);
						swapMade = true;
						i = 0;
					}

				}

				if (!swapMade)
				{

					for (int b = backIndex; b > pivotIndex; b--)
					{
						if (numbers[b] < numbers[pivotIndex])
						{
							Swap(pivotIndex, b, numbers);
							//swapMade = true;
							break;
						}
					}
					for (int c = frontIndex; c < pivotIndex; c++)
					{
						if (numbers[c] > numbers[pivotIndex])
						{
							Swap(pivotIndex, c, numbers);
							i = 0;
							//swapMade = true;
							break;
						}
					}
				}
			}
			return pivotIndex;

		}

		public static void Swap(int place1, int place2, List<int> numbers)
		{
			int temp = numbers[place1];
			numbers[place1] = numbers[place2];
			numbers[place2] = temp;
		}
	}
}
