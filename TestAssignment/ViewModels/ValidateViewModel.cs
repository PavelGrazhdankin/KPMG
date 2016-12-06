using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestAssignment.ViewModels
{
    public class ValidateViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors;

        [Display(AutoGenerateField = false)]
        protected Func<string, object, List<string>> ValidateDelegate { get; set; }

        [Display(AutoGenerateField = false)]
        public string this[string columnName]
        {
            get
            {
                Validate(columnName);
                return Error;
            }
        }

        [Display(AutoGenerateField = false)]
        public string Error { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected ValidateViewModel()
        {
            _errors = new Dictionary<string, List<string>>();
        }

        private string Validate(string columnName)
        {
            List<string> errors = null;

            if (ValidateDelegate != null)
                errors = ValidateDelegate(columnName, this);

            if (errors != null && errors.Any())
            {
                Error = errors.Aggregate((i, j) => String.Format("{0}{1}{2}", i, Environment.NewLine, j));
            }
            else
                Error = null;

            if (errors != null)
                UpdateInDictionary(columnName, errors);

            return Error;
        }

        private void UpdateInDictionary(string columnName, List<string> errors)
        {
            if (_errors.ContainsKey(columnName))
                _errors[columnName] = errors;
            else
                _errors.Add(columnName, errors);
        }
    }
}