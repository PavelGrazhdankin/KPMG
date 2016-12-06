using System.Collections.Generic;

namespace TestAssignment.Models
{
    public interface IRecordValidator
    {
        List<string> Validate(string account, string description, string currencyCode, int? value);
    }
}