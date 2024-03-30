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
	}
}
