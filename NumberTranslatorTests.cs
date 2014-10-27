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
	}
}
