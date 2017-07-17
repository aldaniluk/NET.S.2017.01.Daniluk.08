using System;
using System.Globalization;

namespace Logic
{
    public class CustomerExtension : ICustomFormatter, IFormatProvider
    {
        #region private fields
        private readonly IFormatProvider parentFormatProvider;
        #endregion

        #region ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public CustomerExtension() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Ctor with parameter.
        /// </summary>
        /// <param name="parent">Format provider.</param>
        public CustomerExtension(IFormatProvider parent)
        {
            parentFormatProvider = parent;
        }
        #endregion

        
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        /// <summary>
        /// Converts Customer object into string representation using additional formats.
        /// </summary>
        /// <param name="format">Format of string representation.</param>
        /// <param name="obj">Customer object for converting.</param>
        /// <param name="formatProvider">Format provider.</param>
        /// <returns>String representation of the customer.</returns>
        public string Format(string format, object obj, IFormatProvider formatProvider)
        {
            Customer customer = obj as Customer;
            if (ReferenceEquals(customer, null)) throw new ArgumentNullException($"{nameof(customer)} is null.");

            if (string.IsNullOrEmpty(format)) format = "1+";
            if (ReferenceEquals(formatProvider, null)) formatProvider = parentFormatProvider;

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
