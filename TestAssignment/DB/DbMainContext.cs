using System;
using System.Data.Entity;
using System.Threading.Tasks;
using TestAssignment.Models;

namespace TestAssignment.DB
{
    public class DbMainContext : DbContext
    {
        private readonly Action<object> _creating;
        private readonly Action<object> _created;
        public bool NewDatabase { get; private set; }

        public DbMainContext(string connectionString, Action<object> creating, Action<object> created)
            : base(connectionString)
        {
            _creating = creating;
            _created = created;
            var init = new DbInitializer();
            Database.SetInitializer(init);

            if (!Database.Exists(connectionString))
            {

                if (_creating != null)
                    _creating(connectionString);

                init.InitializeDatabase(this);
                NewDatabase = true;

                if (_created != null)
                    _created(connectionString);
            }
        }

        public DbSet<TaxFigure> TaxFigures { get; set; }
    }
}