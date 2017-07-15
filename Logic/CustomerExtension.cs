using System;
using System.Globalization;

namespace Logic
{
    public class CustomerExtension : ICustomFormatter
    {
        /// <summary>
        /// Converts Customer object into string representation using additional formats.
        /// </summary>
        /// <param name="format">Format of string representation.</param>
        /// <param name="obj">Customer object for converting.</param>
        /// <param name="formatProvider">Format provider.</param>
        /// <returns>String representation of the customer.</returns>
        public string Format(string format, object obj, IFormatProvider formatProvider = null)
        {
            Customer customer = obj as Customer;
            if (ReferenceEquals(customer, null)) throw new ArgumentNullException($"{nameof(customer)} is null.");

            if (string.IsNullOrEmpty(format)) format = "1+";
            if (ReferenceEquals(formatProvider, null)) formatProvider = CultureInfo.InvariantCulture;

            switch (format.ToUpperInvariant())
            {
                case "1+":
                    return $"Customer record: name - {customer.Name}, revenue - {customer.Revenue.ToString("N", NumberFormatInfo.InvariantInfo)}, phone - {customer.ContactPhone}";
                case "2+":
                    return $"Customer record: phone - {customer.ContactPhone}";
                case "4+":
                    return $"Customer record: name - {customer.Name}";
                default:
                    throw new FormatException($"This format {format} is not supported.");
            }
        }
    }
}
