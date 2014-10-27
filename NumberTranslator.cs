using System;

namespace NumberTranslator
{
	public class Translator
	{
		private readonly NumbersToWordsCalculator _numbersToWordsCalculator = new NumbersToWordsCalculator();

		public string NumberProcessing(int number)
		{
			if (_numbersToWordsCalculator.NumbersToWords.ContainsKey(number))
			{
				return _numbersToWordsCalculator.NumbersToWords[number];
			}

			var numberOfDigits = (int) Math.Floor(Math.Log10(number) + 1);
			if (numberOfDigits == 2)
			{
				var tensDigit = (number/10)*10;
				var unitsDigit = number - tensDigit;
				if (tensDigit == 10)
				{
					return _numbersToWordsCalculator.NumbersToWords[unitsDigit] + "teen";
				}
				if (unitsDigit > 0)
				{
					return _numbersToWordsCalculator.NumbersToWords[tensDigit] + " " +
						_numbersToWordsCalculator.NumbersToWords[unitsDigit];
				}
			}

			if (numberOfDigits == 3)
			{
				var hundredsDigit = (number/100);
				var hundredsNumber = hundredsDigit*100;
				var tensDigit = ((number - hundredsNumber)/10)*10;
				var unitsDigit = number - hundredsNumber - tensDigit;
				if (tensDigit == 0 && unitsDigit == 0)
				{
					return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred";
				}
				if (tensDigit == 10)
				{
					var tensNumber = tensDigit + unitsDigit;
					if (_numbersToWordsCalculator.NumbersToWords.ContainsKey(tensNumber))
					{
						return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred and " +
						       _numbersToWordsCalculator.NumbersToWords[tensNumber];
					}
					return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred and " +
					       _numbersToWordsCalculator.NumbersToWords[unitsDigit] + "teen";
				}
				if (tensDigit == 0)
				{
					return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred and " +
						_numbersToWordsCalculator.NumbersToWords[unitsDigit];
				}
				if (unitsDigit == 0)
				{
					return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred and " +
						_numbersToWordsCalculator.NumbersToWords[tensDigit];
				}
				return _numbersToWordsCalculator.NumbersToWords[hundredsDigit] + " hundred and " +
					_numbersToWordsCalculator.NumbersToWords[tensDigit] + " " +
					_numbersToWordsCalculator.NumbersToWords[unitsDigit];
			}

			return _numbersToWordsCalculator.NumbersToWords[number];
		}
	}
}