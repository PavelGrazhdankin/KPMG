
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestAssignment.Models
{
    public class RecordValidator : IRecordValidator
    {
        private static RecordValidator _instance = new RecordValidator();

        private List<string> _currencyCodes;

        private RecordValidator()
        {
            _currencyCodes = GetCurrencyCodesByIso4217();
        }

        public static RecordValidator CreateInstance()
        {
            return _instance;
        }

        private List<string> GetCurrencyCodesByIso4217()
        {
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo country = new RegionInfo(culture.LCID);
                if (countries.Where(p => p.Name == country.Name).Count() == 0)
                    countries.Add(country);
            }
            return countries.OrderBy(p => p.EnglishName).Select(x => x.ISOCurrencySymbol.ToUpper()).ToList();
        }

        public List<string> Validate(string account, string description, string currencyCode, int? value)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(account))
                errors.Add("Account is null or empty");

            if (string.IsNullOrWhiteSpace(description))
                errors.Add("Description is null or empty");

            if (!_currencyCodes.Contains(currencyCode.ToUpper()))
                errors.Add("Unknown currency code");

            if (value == null)
                errors.Add("Value must be a valid number");

            return errors;
        }
    }
}