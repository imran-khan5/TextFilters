using System;
using NUnit.Framework;
using TextFilters.ChainOfResponsibility.Handlers;

namespace TextFilters.Tests
{
    [TestFixture]
    public class VowelInMiddleFilterTests
    {
        [Test]
        [TestCase(false, "elmwo")]
        [TestCase(true, "jlewp")]
        [TestCase(true, "datw")]
        [TestCase(false, "often")]
        [TestCase(true, "ease")]
        public void With_valid_input_valid_response_returned(bool expected, string inputText)
        {
            var sut = GetSut();

            var result = sut.Handle(inputText);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void With_invalid_input_exception_returned()
        {
            Assert.Throws<ArgumentException>(() => GetSut().Handle(""));
        }

        private VowelInMiddleFilter GetSut()
        {
            return new VowelInMiddleFilter();
        }
    }
}
