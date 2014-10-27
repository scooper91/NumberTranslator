using System.Collections.Generic;

namespace NumberTranslator
{
	public class NumbersToWordsDictionary
	{
		public readonly Dictionary<int,string> NumbersToWords = new Dictionary<int, string>
			{
				{ 0, "zero" },
				{ 1, "one" },
				{ 2, "two" },
				{ 3, "three" },
				{ 4, "four" },
				{ 5, "five" },
				{ 6, "six" },
				{ 7, "seven" },
				{ 8, "eight" },
				{ 9, "nine" },
				{ 10, "ten" },
				{ 11, "eleven" },
				{ 12, "twelve" },
				{ 13, "thirteen" },
				{ 15, "fifteen" },
				{ 18, "eighteen" },
				{ 20, "twenty" },
				{ 30, "thirty" },
				{ 40, "forty" },
				{ 50, "fifty" },
				{ 60, "sixty" },
				{ 70, "seventy" },
				{ 80, "eighty" },
				{ 90, "ninety" }
			};
	}
}