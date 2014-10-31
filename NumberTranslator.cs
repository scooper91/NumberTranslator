using System;

namespace NumberTranslator
{
	public class Translator
	{
		private readonly NumbersToWordsDictionary _numbersToWordsDictionary = new NumbersToWordsDictionary();

		public string NumberProcessing(int number)
		{
			string numberJoiner = "";
			var numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);

			if (DictionaryContains(number))
			{
				numberJoiner = AddNumberToOutput(number);
				Console.WriteLine(numberJoiner);
				return AddNumberToOutput(number);
			
			}

			else if (numberOfDigits == 2)
			{
				var tensDigit = (number / 10) * 10;
				var unitsDigit = number - tensDigit;
				if (tensDigit == 10)
				{
					numberJoiner = AddTeenNumberToOutput(unitsDigit);
					return AddTeenNumberToOutput(unitsDigit);
				}
				if (unitsDigit > 0)
				{
					numberJoiner = AddNumberToOutput(tensDigit) + " " + AddNumberToOutput(unitsDigit);
					Console.WriteLine(numberJoiner);
					return AddNumberToOutput(tensDigit) + " " + AddNumberToOutput(unitsDigit);
				}
			}

			else if (numberOfDigits == 3)
			{
				var hundredsDigit = (number / 100);
				var hundredsNumber = hundredsDigit * 100;
				var tensDigit = ((number - hundredsNumber) / 10) * 10;
				var unitsDigit = number - hundredsNumber - tensDigit;

				if (tensDigit == 0 && unitsDigit == 0)
				{
					return AddNumberToOutput(hundredsDigit) + " hundred";
				}
				if (tensDigit == 10)
				{
					var tensNumber = tensDigit + unitsDigit;
					if (DictionaryContains(tensNumber))
					{
						return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddNumberToOutput(tensNumber);
					}
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddTeenNumberToOutput(unitsDigit);
				}
				if (tensDigit == 0)
				{
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddNumberToOutput(unitsDigit);
				}
				if (unitsDigit == 0)
				{
					return AddCompleteHundredNumberToOutput(hundredsDigit) +
						AddNumberToOutput(tensDigit);
				}
				return AddCompleteHundredNumberToOutput(hundredsDigit) +
					AddNumberToOutput(tensDigit) + " " +
					AddNumberToOutput(unitsDigit);
			}

			else if (numberOfDigits == 4)
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
					return AddNumberToOutput(thousandsDigit) + " thousand";
				}
				if (hundredsDigit != 0)
				{
					if (tensNumber == 0)
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) +
						       AddNumberToOutput(hundredsDigit) + " hundred";
					}
					if (tensNumber != 0 && _numbersToWordsDictionary.NumbersToWords.ContainsKey(teenNumber))
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) +
							   AddCompleteHundredNumberToOutput(hundredsDigit) + AddNumberToOutput(teenNumber);
					}
				}
				if (hundredsDigit == 0)
				{
					if (tensNumber != 0 && _numbersToWordsDictionary.NumbersToWords.ContainsKey(teenNumber))
					{
						return AddCompleteThousandsNumberToOutput(thousandsDigit) + "and " + AddNumberToOutput(teenNumber);
					}
				}
				return AddCompleteThousandsNumberToOutput(thousandsDigit) +
						AddCompleteHundredNumberToOutput(hundredsDigit) + AddTeenNumberToOutput(unitsNumber);
			}
			return numberJoiner;
		}

		private string AddTeenNumberToOutput(int unitsDigit)
		{
			return AddNumberToOutput(unitsDigit) + "teen";
		}

		private string AddCompleteHundredNumberToOutput(int hundredsDigit)
		{
			return AddNumberToOutput(hundredsDigit) + " hundred and ";
		}

		private string AddCompleteThousandsNumberToOutput(int thousandsDigit)
		{
			return AddNumberToOutput(thousandsDigit) + " thousand ";
		}

		private bool DictionaryContains(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords.ContainsKey(number);
		}

		private string AddNumberToOutput(int number)
		{
			return _numbersToWordsDictionary.NumbersToWords[number];
		}
	}
}