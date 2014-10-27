using System.Collections.Generic;
using System.Linq;

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
			return _numbersToWords[number];
		}
	}
}