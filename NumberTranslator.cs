using System;

namespace NumberTranslator
{
	public class Translator
	{
		private readonly NumbersToWordsDictionary _numbersToWordsDictionary = new NumbersToWordsDictionary();

		public string NumberProcessing(int number)
		{
			if (DictionaryContains(number))
			{
				return AddNumberToOutput(number);
			}

			var numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);

			if (numberOfDigits == 2)
			{
				var tensDigit = (number / 10) * 10;
				var unitsDigit = number - tensDigit;
				if (tensDigit == 10)
				{
					return AddTeenNumberToOutput(unitsDigit);
				}
				if (unitsDigit > 0)
				{
					return AddTensToOutput(tensDigit) + " " + AddUnitsToOutput(unitsDigit);
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
					return AddHundredsToOutput(hundredsDigit) + " hundred";
				}
				if (tensDigit == 10)
				{
					var tensNumber = tensDigit + unitsDigit;
					if (DictionaryContains(tensNumber))
					{
						return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddTensToOutput(tensNumber);
					}
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddTeenNumberToOutput(unitsDigit);
				}
				if (tensDigit == 0)
				{
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddUnitsToOutput(unitsDigit);
				}
				if (unitsDigit == 0)
				{
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddTensToOutput(tensDigit);
				}
				return AddCompleteHundredNumberToOutput(hundredsDigit) +
					AddTensToOutput(tensDigit) + " " +
					AddUnitsToOutput(unitsDigit);
			}

			if (numberOfDigits == 4)
			{
				var thousandsDigit = (number/1000);
				var thousandsNumber = thousandsDigit*1000;
				var hundredsDigit = (number - thousandsNumber)/100;
				var hundredsNumber = hundredsDigit*100;
				var teenNumber = number - thousandsNumber - hundredsNumber;
				var tensDigit = (number - thousandsNumber - hundredsNumber)/10;
				var tensNumber = tensDigit*10;
				var unitsNumber = number - thousandsNumber - hundredsNumber - tensNumber;

				if (hundredsDigit == 0 && tensDigit == 0 && unitsNumber == 0)
				{
					return AddThousandsToOutput(thousandsDigit) + " thousand";
				}
				if (hundredsDigit != 0)
				{
					if (tensNumber == 0)
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) +
						       AddHundredsToOutput(hundredsDigit) + " hundred";
					}
					if (tensNumber != 0 && _numbersToWordsDictionary.NumbersToWords.ContainsKey(teenNumber))
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) +
							   AddCompleteHundredNumberToOutput(hundredsDigit) + AddTensToOutput(teenNumber);
					}
				}
				if (hundredsDigit == 0)
				{
					if (tensNumber != 0 && _numbersToWordsDictionary.NumbersToWords.ContainsKey(teenNumber))
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) + "and " + AddTensToOutput(teenNumber);
					}
				}
				return AddCompleteThousandsNumberToOutput(thousandsDigit) +
						AddCompleteHundredNumberToOutput(hundredsDigit) + AddTeenNumberToOutput(unitsNumber);
			}
			return "";
		}

		private string AddTeenNumberToOutput(int unitsDigit)
		{
			return AddUnitsToOutput(unitsDigit) + "teen";
		}

		private string AddCompleteHundredNumberToOutput(int hundredsDigit)
		{
			return AddHundredsToOutput(hundredsDigit) + " hundred and ";
		}

		private string AddCompleteThousandsNumberToOutput(int thousandsDigit)
		{
			return AddThousandsToOutput(thousandsDigit) + " thousand ";
		}

		private string AddThousandsToOutput(int thousandsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[thousandsDigit];
		}

		private bool DictionaryContains(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords.ContainsKey(number);
		}

		private string AddNumberToOutput(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords[number];
		}

		private string AddHundredsToOutput(int hundredsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[hundredsDigit];
		}

		private string AddTensToOutput(int tensDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[tensDigit];
		}

		private string AddUnitsToOutput(int unitsDigit)
		{
			return _numbersToWordsDictionary.NumbersToWords[unitsDigit];
		}
	}
}