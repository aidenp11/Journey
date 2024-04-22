using SortingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphLibrary
{
	public class Isomorph
	{
		private static List<char> lettersFromWord = new List<char>();
		public struct WordData
		{
			public WordData(string word, string exactIsoVal, string looseIsoVal)
			{
				Word = word;
				ExactIsoVal = exactIsoVal;
				LooseIsoVal = looseIsoVal;
			}


			public string Word { get; }
			public string ExactIsoVal { get; }
			public string LooseIsoVal { get; }
		}
		public static string Create(string inputPath, string outputPath)
		{
			string[] words = File.ReadAllLines("IsomorphTests/" + inputPath);
			List<WordData> list = new List<WordData>();
			foreach (string word in words)
			{
				string exactVal = ConvertStringToExactVal(word);
				string looseVal = ConvertStringToLooseVal(word);
				WordData wordData = new WordData(word, exactVal, looseVal);
				list.Add(wordData);
			}
			string finalString = "";
			WordData[] ExactIsoList = list.ToArray();
			WordData[] LooseIsoList = list.ToArray();
			ExactIsomorphSort(ExactIsoList);
			LooseIsomorphSort(LooseIsoList);
			finalString = FinalIsomorphStuff(ExactIsoList, LooseIsoList);
			File.WriteAllText("IsomorphTests/" + outputPath, finalString);
			return finalString;
		}

		public static void ExactIsomorphSort(WordData[] items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Length; i++)
			{
				int selected = i;

				for (int o = i + 1; o < items.Length; o++)
				{
					if (items[o].ExactIsoVal.CompareTo(items[selected].ExactIsoVal) < 0)
					{
						WordData og = items[selected];
						items[selected] = items[o];
						items[o] = og;
						o--;

					}
				}
			}
		}

		public static void LooseIsomorphSort(WordData[] items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Length; i++)
			{
				int selected = i;

				for (int o = i + 1; o < items.Length; o++)
				{
					if (items[o].ExactIsoVal.CompareTo(items[selected].ExactIsoVal) < 0)
					{
						WordData og = items[selected];
						items[selected] = items[o];
						items[o] = og;
						o--;

					}
				}
			}
		}

		public static string ConvertStringToExactVal(string word)
		{
			lettersFromWord.Clear();
			string exactValue = "";
			int value = 0;
			foreach (char c in word)
			{
				if (!lettersFromWord.Contains(c))
				{
					lettersFromWord.Add(c);
					exactValue += value;
					value++;
				}
				else if (lettersFromWord.Contains(c))
				{
					exactValue += lettersFromWord.IndexOf(c);
				}
			}
			return exactValue;
		}

		public static string ConvertStringToLooseVal(string word)
		{
			List<int> counts = new List<int>();
			string looseValue = "";
			foreach (char c in lettersFromWord)
			{
				int count = countRepeats(word, c);
				counts.Add(count);
			}

			int[] countsArray = counts.ToArray();
			Sorter.SelectionSort(countsArray);
			foreach (int count in countsArray) { looseValue += count; }
			return looseValue;
		}

		public static int countRepeats(string word, char character)
		{
			int count = 0;
			foreach (char c in word)
			{
				if (character == c) { count++; }
			}
			return count;
		}

		public static string FinalIsomorphStuff(WordData[] Exact, WordData[] Loose)
		{
			StringBuilder sb = new StringBuilder();
			List<string> list = new List<string>();
			int count = 1;
			int i = 0;
			string currentIso = Exact[i].ExactIsoVal;
			sb.Append("Exact Isomorphs \n");
			sb.Append(currentIso + ": ");
			for (; i < Exact.Count(); i++)
			{
				if (Exact[i].ExactIsoVal == Exact[i + 1].ExactIsoVal)
				{
					count++;
					sb.Append(Exact[i].Word + " ");
				}
				else if (Exact[i].ExactIsoVal != Exact[i + 1].ExactIsoVal && count > 1)
				{
					sb.Append(Exact[i].Word + " ");
					count = 1;
					currentIso = Exact[i + 1].ExactIsoVal;
					sb.Append("\n" + currentIso + ": ");
				}
				else if (Exact[i].ExactIsoVal != Exact[i + 1].ExactIsoVal && count <= 1)
				{
					count = 1;
					sb.Replace(currentIso + ": ", "");
					if (i + 1 == Exact.Count() - 1)
					{
						list.Add(Exact[i].Word + " ");
						break;
					}
					else if (i + 1 != Exact.Count() - 1)
					{
						list.Add(Exact[i].Word + " ");
						currentIso = Exact[i + 1].ExactIsoVal;
						sb.Append(currentIso + ": ");
					}
				}
			}

			count = 1;
			i = 0;
			currentIso = Loose[i].LooseIsoVal;
			sb.Append("\nLoose Isomorphs");
			sb.Append("\n" + currentIso + ": ");
			for (; i < Loose.Count(); i++)
			{
				if (Loose[i].LooseIsoVal == Loose[i + 1].LooseIsoVal)
				{
					count++;
					sb.Append(Loose[i].Word + " ");
				}
				else if (Loose[i].LooseIsoVal != Loose[i + 1].LooseIsoVal && count > 1)
				{
					sb.Append(Loose[i].Word + " ");
					count = 1;
					currentIso = Loose[i + 1].LooseIsoVal;
					sb.Append("\n" + currentIso + ": ");
					if (i + 1 == Loose.Count() - 1)
					{
						sb.Replace(currentIso + ": ", "");
						list.Add(Loose[i].Word + " ");
						break;
					}
				}
				else if (Loose[i].LooseIsoVal != Loose[i + 1].LooseIsoVal && count <= 1)
				{
					count = 1;
					sb.Replace(currentIso + ": ", "");
					if (i + 1 == Loose.Count() - 1)
					{
						list.Add(Loose[i].Word + " ");
						break;
					}
					else if (i + 1 != Loose.Count() - 1)
					{
						list.Add(Loose[i].Word + " ");
						currentIso = Loose[i + 1].LooseIsoVal;
						sb.Append(currentIso + ": ");
					}
				}
			}

			sb.Append("\nNot Isomorphs \n");
			foreach (string item in list)
			{
				sb.Append(item + " ");
			}
			return sb.ToString();
		}
	}
}
