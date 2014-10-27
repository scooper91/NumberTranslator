using System.Diagnostics;
using NUnit.Framework;

namespace NumberTranslator
{
	public class NumberTranslatorTests
	{
		[Test]
		public void Should_return_zero_when_0_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(0), Is.EqualTo("zero"));
		}

		[Test]
		public void Should_return_one_when_1_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(1), Is.EqualTo("one"));
		}

		[Test]
		public void Should_return_two_when_two_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(2), Is.EqualTo("two"));
		}

		[Test]
		public void Should_return_ten_when_10_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(10), Is.EqualTo("ten"));
		}

		[Test]
		public void Should_return_20_when_twenty_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(20), Is.EqualTo("twenty"));
		}

		[Test]
		public void Should_return_twenty_one_when_21_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(21), Is.EqualTo("twenty one"));
		}

		[Test]
		public void Should_return_twenty_five_when_25_entered()
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(25), Is.EqualTo("twenty five"));
		}

		[TestCase(14, "fourteen")]
		[TestCase(16, "sixteen")]
		[TestCase(17, "seventeen")]
		[TestCase(19, "nineteen")]
		public void Should_return_teen_numbers(int numberInput, string numberOutput)
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}

		[TestCase(100, "one hundred")]
		[TestCase(101, "one hundred and one")]
		[TestCase(110, "one hundred and ten")]
		[TestCase(111, "one hundred and eleven")]
		[TestCase(117, "one hundred and seventeen")]
		[TestCase(200, "two hundred")]
		public void Should_return_hundreds_numbers(int numberInput, string numberOutput)
		{
			var translator = new Translator();

			Assert.That(translator.NumberProcessing(numberInput), Is.EqualTo(numberOutput));
		}
	}
}
