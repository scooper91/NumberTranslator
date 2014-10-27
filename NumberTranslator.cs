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

			var numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);

			if (numberOfDigits == 2)
			{
				var tensDigit = (number / 10) * 10;
				var unitsDigit = number - tensDigit;
				if (tensDigit == 10)
				{
					return AddUnitsToDictionary(unitsDigit) + "teen";
				}
				if (unitsDigit > 0)
				{
					return AddTensToDictionary(tensDigit) + " " +
						AddUnitsToDictionary(unitsDigit);
				}
			}

			if (numberOfDigits == 3)
			{
				var hundredsDigit = (number / 100);
				var hundredsNumber = hundredsDigit * 100;
				var tensDigit = ((number - hundredsNumber) / 10) * 10;
				var unitsDigit = number - hundredsNumber - tensDigit;
				if (tensDigit == 0 && unitsDigit == 0)
				{
					return AddHundredsToDictionary(hundredsDigit) + " hundred";
				}
				if (tensDigit == 10)
				{
					var tensNumber = tensDigit + unitsDigit;
					if (_numbersToWordsCalculator.NumbersToWords.ContainsKey(tensNumber))
					{
						return AddHundredsToDictionary(hundredsDigit) + " hundred and " +
						AddTensToDictionary(tensNumber);
					}
					return AddHundredsToDictionary(hundredsDigit) + " hundred and " +
						AddUnitsToDictionary(unitsDigit) + "teen";
				}
				if (tensDigit == 0)
				{
					return AddHundredsToDictionary(hundredsDigit) + " hundred and " +
						AddUnitsToDictionary(unitsDigit);
				}
				if (unitsDigit == 0)
				{
					return AddHundredsToDictionary(hundredsDigit) + " hundred and " +
						AddTensToDictionary(tensDigit);
				}
				return AddHundredsToDictionary(hundredsDigit) + " hundred and " +
					AddTensToDictionary(tensDigit) + " " +
					AddUnitsToDictionary(unitsDigit);
			}

			return _numbersToWordsCalculator.NumbersToWords[number];
		}

		private string AddHundredsToDictionary(int hundredsDigit)
		{
			return _numbersToWordsCalculator.NumbersToWords[hundredsDigit];
		}

		private string AddTensToDictionary(int tensDigit)
		{
			return _numbersToWordsCalculator.NumbersToWords[tensDigit];
		}

		private string AddUnitsToDictionary(int unitsDigit)
		{
			return _numbersToWordsCalculator.NumbersToWords[unitsDigit];
		}
	}
}