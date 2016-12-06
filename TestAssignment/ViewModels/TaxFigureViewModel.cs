using System.Linq;
using TestAssignment.Models;

namespace TestAssignment.ViewModels
{
    public class TaxFigureViewModel : ViewModelBase, ITaxFigure
    {
        private readonly TaxFigure _record;

        public string Account
        {
            get { return _record.Account; }
            set
            {
                _record.Account = value;
                OnPropertyChanged(nameof(Account));
            }
        }

        public string Description
        {
            get { return _record.Description; }
            set
            {
                _record.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string CurrencyCode
        {
            get { return _record.CurrencyCode; }
            set
            {
                _record.CurrencyCode = value;
                OnPropertyChanged(nameof(CurrencyCode));
            }
        }

        public int? Value
        {
            get { return _record.Value; }
            set
            {
                _record.Value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public string Errors
        {
            get { return string.Join(",", _record.ValidationErrors); }
        }

        public TaxFigureViewModel(TaxFigure record)
        {
            _record = record;
        }
    }
}