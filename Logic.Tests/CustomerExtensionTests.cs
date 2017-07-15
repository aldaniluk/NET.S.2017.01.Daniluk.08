using NUnit.Framework;
using System;

namespace Logic.Tests
{
    [TestFixture]
    public class CustomerExtensionTests
    {
        [TestCase("1+", null, ExpectedResult = "Customer record: name - Jeffrey Richter, revenue - 1,000,000.00, phone - +1 (425) 555-0100")]
        [TestCase("2+", null, ExpectedResult = "Customer record: phone - +1 (425) 555-0100")]
        [TestCase("4+", null, ExpectedResult = "Customer record: name - Jeffrey Richter")]
        public string ToString_CustomerExtensionFormats_PositiveTest(string format, IFormatProvider formatProvider)
        {
            CustomerExtension ce = new CustomerExtension();
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return ce.Format(format, c, formatProvider);
        }

        [Test]
        public void ToString_InvalidCustomerExtensionFormat_ThrowsFormatException()
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(() => c.ToString("1++", null));
        }

    }
}
