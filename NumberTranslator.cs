using System;

namespace NumberTranslator
{
	public class Translator
	{
		private readonly NumbersToWordsDictionary _numbersToWordsDictionary = new NumbersToWordsDictionary();
		private string _hundredText;

		public string NumberProcessing(int number)
		{
			if (DictionaryContains(number))
			{
				return AddNumberToDictionary(number);
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
					return AddTensToDictionary(tensDigit) + " " + AddUnitsToDictionary(unitsDigit);
				}
			}

			if (numberOfDigits == 3)
			{
				_hundredText = " hundred and ";

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
					if (DictionaryContains(tensNumber))
					{
						return AddHundredsToDictionary(hundredsDigit) + _hundredText +
						AddTensToDictionary(tensNumber);
					}
					return AddHundredsToDictionary(hundredsDigit) + _hundredText +
						AddUnitsToDictionary(unitsDigit) + "teen";
				}
				if (tensDigit == 0)
				{
					return AddHundredsToDictionary(hundredsDigit) + _hundredText +
						AddUnitsToDictionary(unitsDigit);
				}
				if (unitsDigit == 0)
				{
					return AddHundredsToDictionary(hundredsDigit) + _hundredText +
						AddTensToDictionary(tensDigit);
				}
				return AddHundredsToDictionary(hundredsDigit) + _hundredText +
					AddTensToDictionary(tensDigit) + " " +
					AddUnitsToDictionary(unitsDigit);
			}

			return "";
		}

		private bool DictionaryContains(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords.ContainsKey(number);
		}

		private string AddNumberToDictionary(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords[number];
		}

		private string AddHundredsToDictionary(int hundredsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[hundredsDigit];
		}

		private string AddTensToDictionary(int tensDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[tensDigit];
		}

		private string AddUnitsToDictionary(int unitsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[unitsDigit];
		}
	}
}