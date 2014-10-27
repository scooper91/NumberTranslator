using System;
using System.Collections.Generic;

namespace NumberTranslator
{
	public class Translator
	{
		readonly Dictionary<int,string> _numbersToWords = new Dictionary<int, string>
			{
				{ 0, "zero" },
				{ 1, "one" },
				{ 2, "two" },
				{ 3, "three" },
				{ 4, "four" },
				{ 5, "five" },
				{ 10, "ten" },
				{ 20, "twenty" }
			};  

		public object NumberProcessing(int number)
		{
			var numberOfDigits = Math.Floor(Math.Log10(number) + 1);
			if (numberOfDigits > 1)
			{
				var firstDigit = number/10;
				firstDigit *= 10;
				var secondDigit = number - firstDigit;
				if (secondDigit > 0)
				{
					return _numbersToWords[firstDigit] + " " + _numbersToWords[secondDigit];
				}
			}

			return _numbersToWords[number];
		}
	}
}