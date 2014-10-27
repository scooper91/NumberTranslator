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
				{ 20, "twenty" },
			};

		public string NumberProcessing(int number)
		{
			var numberOfDigits = (int) Math.Floor(Math.Log10(number) + 1);
			if (numberOfDigits == 2)
			{
				var tensDigit = (number/10)*10;
				var unitsDigit = number - tensDigit;
				if (unitsDigit > 0)
				{
					return _numbersToWords[tensDigit] + " " + _numbersToWords[unitsDigit];
				}
			}

			if (numberOfDigits == 3)
			{
				var hundredsDigit = (number/100);
				var hundredsNumber = hundredsDigit*100;
				var tensDigit = ((number - hundredsNumber)/10)*10;
				var unitsDigit = number - hundredsNumber - tensDigit;
				if (tensDigit == 0)
				{
					return _numbersToWords[hundredsDigit] + " hundred and " + _numbersToWords[unitsDigit];
				}
				if (unitsDigit == 0)
				{
					return _numbersToWords[hundredsDigit] + " hundred and " + _numbersToWords[tensDigit];
				}
				return _numbersToWords[hundredsDigit] + " hundred and " + 
					_numbersToWords[tensDigit] + " " + 
					_numbersToWords[unitsDigit];
			}

			return _numbersToWords[number];
		}
	}
}