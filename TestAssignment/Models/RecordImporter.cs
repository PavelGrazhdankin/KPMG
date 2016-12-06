using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TestAssignment.DB;
using TestAssignment.ViewModels;

namespace TestAssignment.Models
{
    public class RecordImporter
    {
        private readonly Action _updateViewAction;
        private TaskFactory _factory;
        private List<Task> _tasks; 
        private int _count;
        private bool _canceled;
        private BackgroundWorker _worker;

        public string FileName { get; set; }

        public ConcurrentBag<TaxFigureViewModel> Errors { get; private set; }

        public int Count
        {
            get { return _count; }
        }

        public bool InProcess
        {
            get { return !_tasks.All(x => x.IsCompleted || x.IsCanceled || x.IsFaulted); }
        }

        public RecordImporter(string fileName, Action updateViewAction = null)
        {
            FileName = fileName;
            _updateViewAction = updateViewAction;
            _factory = new TaskFactory();
            _tasks = new List<Task>();
            Errors = new ConcurrentBag<TaxFigureViewModel>();

            _worker = new BackgroundWorker();
            _worker.DoWork += WorkerOnDoWork;
            _worker.ProgressChanged += WorkerOnProgressChanged;
            _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
        }

        public void Import()
        {
            _worker.RunWorkerAsync();
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {

        }

        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {

        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            if (InProcess)
                return;

            _count = 0;
            _tasks.Clear();

            TaxFigureViewModel tax;
            while (!Errors.IsEmpty)
                Errors.TryTake(out tax);

            foreach (var line in File.ReadLines(FileName))
            {
                if (_canceled)
                    break;

                if (_updateViewAction != null)
                    _updateViewAction();

                HandleLine(line);
            }

            while (InProcess)
            {
                if (_updateViewAction != null)
                    _updateViewAction();
                Thread.Sleep(1000);
            }
        }

        private void HandleLine(string line)
        {
            var task = _factory.StartNew(() =>
            {
                if (_canceled)
                    return;

                var record = new TaxFigure(line);
                if (!record.ValidationErrors.Any())
                    WriteToDb(record);
                else
                    Errors.Add(new TaxFigureViewModel(record));
            });

            _tasks.Add(task);
        }

        private void WriteToDb(TaxFigure record)
        {
            using (var provider = new DbProvider<DbMainContext>())
            {
                provider.AddRecord(record);
                provider.SaveChanges();
                Interlocked.Increment(ref _count);
            }
        }

        public void Cancel()
        {
            _canceled = true;
            _tasks.Clear();
        }
    }
}