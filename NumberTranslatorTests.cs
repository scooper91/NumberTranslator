using NUnit.Framework;

namespace NumberTranslator
{
	public class NumberTranslatorTests
	{
		private Translator _translator;

		[SetUp]
		public void SetUp()
		{
			_translator = new Translator();
		}

		[TestCase(0, "zero")]
		[TestCase(1, "one")]
		[TestCase(2, "two")]
		[TestCase(5, "five")]
		[TestCase(8, "eight")]
		public void Should_return_single_digit_numbers(int numberInput, string numberOutput)
		{
			Assert.That(_translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}

		[TestCase(14, "fourteen")]
		[TestCase(16, "sixteen")]
		[TestCase(17, "seventeen")]
		[TestCase(19, "nineteen")]
		public void Should_return_teen_numbers(int numberInput, string numberOutput)
		{
			Assert.That(_translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}

		[TestCase(10, "ten")]
		[TestCase(20, "twenty")]
		[TestCase(22, "twenty two")]
		[TestCase(29, "twenty nine")]
		public void Should_return_two_digit_numbers(int numberInput, string numberOutput)
		{
			Assert.That(_translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}

		[TestCase(100, "one hundred")]
		[TestCase(101, "one hundred and one")]
		[TestCase(110, "one hundred and ten")]
		[TestCase(111, "one hundred and eleven")]
		[TestCase(117, "one hundred and seventeen")]
		[TestCase(200, "two hundred")]
		public void Should_return_hundreds_numbers(int numberInput, string numberOutput)
		{
			Assert.That(_translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}
	}
}
