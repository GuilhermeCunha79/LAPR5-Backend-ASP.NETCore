using System;
using System.Data;
using System.Text.RegularExpressions;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.Warehouses
{
    public class WarehouseAddress : IValueObject
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public WarehouseAddress()
        {
            this.Street = "";
            this.Number = 0;
            this.PostalCode = "";
            this.Country = "";
        }

        public WarehouseAddress(string street, int number, string postalCode, string country)
        {
            this.Street = ValidateStrings(street);
            this.Number = ValidateNumber(number);
            this.PostalCode = ValidatePostalCode(postalCode);
            this.Country = ValidateStrings(country);
        }

        private int ValidateNumber(int i)
        {
            if (i == 0 || i < 0)
            {
                throw new NullReferenceException($"Number can't be 0 or less than 0.");
            }

            return i;
        }

        private string ValidateStrings(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException("This topic can't be null.");
            }

            return text;
        }
        private string ValidatePostalCode(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException("This topic can't be null.");
            }
            string pattern = @"^\d{4}-\d{3}$";
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(text))
                return text;
            else
                throw new FormatException("Postal Code format must be xxxx-xxx!");
        }
        
        public override string ToString()
        {
            return Street + Number + PostalCode + Country;
        }
    }
}