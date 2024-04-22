using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorter = SortingLibrary.Sorter;
using Isomorph = IsomorphLibrary.Isomorph;
using System.Diagnostics;

//string consoleOut = Isomorph.Create("IsomorphInput1.txt", "foarntie.txt");
//Console.WriteLine(consoleOut);

List<int> numbers1 = new List<int> { 69, 1, 22, 3, 0, 10, 11, 4, 5, 123, 7, 2, 100, 22, 77, 0, 2, 0, 2, 6, 1, 78 };
List<int> numbers = new List<int> { 20,6, 20, 32, 70, 0, 48, 6, 5, 12, 21, 4, 2, 20, 1, 7, 3, 6, 88, 20 };

for (int i = 0; i < numbers.Count; i++)
{

	Console.Write(numbers[i] + " ");
}
Console.WriteLine();

Sorter.QuickSort(numbers, 0, numbers.Count - 1);
for (int i = 0; i < numbers.Count; i++)
{

	Console.Write(numbers[i] + " ");
}
Console.WriteLine();

for (int i = 0; i < numbers1.Count; i++)
{

	Console.Write(numbers1[i] + " ");
}
Console.WriteLine();
Sorter.MergeSort(numbers1);
for (int i = 0; i < numbers1.Count; i++)
{

	Console.Write(numbers1[i] + " ");
}