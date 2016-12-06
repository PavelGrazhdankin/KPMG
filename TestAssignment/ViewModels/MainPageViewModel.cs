using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using TestAssignment.DB;
using TestAssignment.Models;

namespace TestAssignment.ViewModels
{
    public class MainPageViewModel : ValidateViewModel
    {
        private bool _fileNameIsCorrect;
        private RecordImporter _importer;
        private string _connectionString;
        private string _dbConnectResultText;
        private ConnectionStringManager _connectionStringManager;
        private bool _connectionFailed;
        private bool _dbCreating;

        public string FileName
        {
            get { return _importer?.FileName; }
            set
            {
                if (_importer != null)
                {
                    _importer.FileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        public string ResultText
        {
            get { return $"{_dbConnectResultText}{_importer.Count} records were imported successfully."; }
        }

        public List<TaxFigureViewModel> Errors
        {
            get { return _importer.Errors.Select(x => x).ToList(); }
        }

        public bool DbCreating
        {
            get { return _dbCreating;}
            set
            {
                _dbCreating = value;
                OnPropertyChanged(nameof(DbCreating));
            }
        }

        public bool HasErrors
        {
            get { return Errors.Any(); }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _connectionFailed = false;
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        public bool NeedConnectionString
        {
            get { return _connectionStringManager.NeedNewConnectionString(_connectionString) || _connectionFailed; }
        }

        

        public MainPageViewModel()
        {
            _connectionStringManager = new ConnectionStringManager();
            _importer = new RecordImporter(FileName, UpdateView);
            _connectionString = _connectionStringManager.ReadConnectionString("ConnectionString");

            ValidateDelegate += Validate;
        }

        private List<string> Validate(string columnName, object o)
        {
            var errors = new List<string>();

            switch (columnName)
            {
                case nameof(FileName):
                    FileNameIsCorrect = !string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName);
                    if (!FileNameIsCorrect)
                        errors.Add("Please, input correct file name");
                    break;
            }
            return errors;
        }

        public bool FileNameIsCorrect
        {
            get { return _fileNameIsCorrect; }
            set
            {
                _fileNameIsCorrect = value;
                OnPropertyChanged(nameof(FileNameIsCorrect));
            }
        }

        public bool InProcess
        {
            get { return _importer.InProcess; }
        }

        private void UpdateView()
        {
            OnPropertyChanged(nameof(ResultText));
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(Errors));
            OnPropertyChanged(nameof(InProcess));
        }

        #region Commands

        private DelegateCommand _selectFileCommand;
        public ICommand SelectFileCommand
        {
            get
            {
                if (_selectFileCommand == null)
                    _selectFileCommand = new DelegateCommand(SelectFile);

                return _selectFileCommand;
            }
        }

        private void SelectFile(object obj)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select file for the import";
            var result = openFileDialog.ShowDialog();
            if (result == true)
                FileName = openFileDialog.FileName;
        }

        private DelegateCommand _importCommand;

        public ICommand ImportCommand
        {
            get
            {
                if (_importCommand == null)
                    _importCommand = new DelegateCommand(Import);

                return _importCommand;
            }
        }

        private void Import(object obj)
        {
            _importer.Import();
        }

        private DelegateCommand _cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new DelegateCommand(Cancel);

                return _cancelCommand;
            }
        }

        private void Cancel(object obj)
        {
            _importer.Cancel();
        }

        private DelegateCommand _connectDbCommand;

        public ICommand ConnectDbCommand
        {
            get
            {
                if (_connectDbCommand == null)
                    _connectDbCommand = new DelegateCommand(Connect);

                return _connectDbCommand;
            }
        }

        private void Connect(object obj)
        {
            if (NeedConnectionString)
            {
                ShowConnectionFailedMessage();
                return;
            }

            _connectionStringManager.SaveConnectionString(_connectionString);

            _dbConnectResultText = $"Database connected successful{Environment.NewLine}";
            
            using (var provider = new DbProvider<DbMainContext>(Creating, Created))
            {
                _connectionFailed = provider.ConnectionFailed;
                if (_connectionFailed)
                    ShowConnectionFailedMessage();

            }
            OnPropertyChanged(nameof(ResultText));
            OnPropertyChanged(nameof(NeedConnectionString));
        }

        private void ShowConnectionFailedMessage()
        {
            var message = "Failed connecting to the database";
            MessageBox.Show(message);
            _dbConnectResultText = $"{message}{Environment.NewLine}";
            OnPropertyChanged(nameof(ResultText));
        }

        private void Creating(object o)
        {
            DbCreating = true;
        }

        private void Created(object o)
        {
            DbCreating = false;
            _dbConnectResultText = $"{_dbConnectResultText}Database created successful{Environment.NewLine}";
            OnPropertyChanged(nameof(ResultText));
        }

        #endregion
    }
}