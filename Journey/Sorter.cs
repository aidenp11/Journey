using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
