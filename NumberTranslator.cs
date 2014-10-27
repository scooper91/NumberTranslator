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

			if (numberOfDigits == 4)
			{
				var thousandsDigit = (number/1000);
				var thousandsNumber = thousandsDigit*1000;
				var hundredsDigit = (number - thousandsNumber)/100;
				var hundredsNumber = hundredsDigit*100;
				var teenNumber = number - thousandsNumber - hundredsNumber;
				var tensDigit = (number - thousandsNumber - hundredsNumber)/10;
				var tensNumber = tensDigit * 10;
				var unitsNumber = number - thousandsNumber - hundredsNumber - tensNumber;

				if (hundredsDigit == 0 && tensDigit == 0 && unitsNumber == 0)
				{
					return _numbersToWordsDictionary.NumbersToWords[thousandsDigit] + " thousand";
				}
				if (hundredsDigit != 0)
				{
					if (tensNumber == 0)
					{
						return AddThousandsToDictionary(thousandsDigit) + " thousand " +
							AddHundredsToDictionary(hundredsDigit) + " hundred";
					}
					if (tensNumber != 0)
					{
						if (_numbersToWordsDictionary.NumbersToWords.ContainsKey(teenNumber))
						{
							return AddThousandsToDictionary(thousandsDigit) + " thousand " + 
								AddHundredsToDictionary(hundredsDigit) +
								" hundred and " + AddTensToDictionary(teenNumber);
						}
						return AddThousandsToDictionary(thousandsDigit) + " thousand " +
						       AddHundredsToDictionary(hundredsDigit) +
						       " hundred and " + AddTensToDictionary(unitsNumber) + "teen";
					}
				}
				
			}

			return "";
		}

		private string AddThousandsToDictionary(int thousandsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[thousandsDigit];
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