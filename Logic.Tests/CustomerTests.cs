using NUnit.Framework;
using Logic;
using System;

namespace Logic.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("1", null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("G", null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("2", null, ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("3", null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("4", null, ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("5", null, ExpectedResult = "Customer record: 1000000")]
        public string ToString_DifferentFormats_PositiveTest(string format, IFormatProvider formatProvider)
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return c.ToString(format, formatProvider);
        }

        [Test]
        public void ToString_InvalidFormat_ThrowsFormatException()
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(() => c.ToString("11", null));
        }

    }
}
