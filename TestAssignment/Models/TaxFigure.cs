using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace TestAssignment.Models
{
    public class TaxFigure : ITaxFigure
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Description { get; set; } 
        [Required]
        public string CurrencyCode { get; set; } 
        [Required]
        public int? Value { get; set; }

        [NotMapped]
        public List<string> ValidationErrors { get; private set; }

        private TaxFigure()
        {
            Id = Guid.NewGuid();
        }

        public TaxFigure(string account, string description, string currencyCode, int value)
            :this()
        {
            Account = account;
            Description = description;
            CurrencyCode = currencyCode;
            Value = value;
        }

        public TaxFigure(string line)
            :this()
        {
            char _separator = ',';

            var items = line.Split(_separator);
            var validator = RecordValidator.CreateInstance();

            int value = 0;
            var res = int.TryParse(items[3], out value);

            ValidationErrors = validator.Validate(items[0], items[1], items[2], res ? value : (int?) null);

            Account = items[0];
            Description = items[1];
            CurrencyCode = items[2];
            Value = res ? value : (int?) null;
        }
    }
}