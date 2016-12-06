using System.Data.Entity;

namespace TestAssignment.DB
{
    public class DbInitializer : CreateDatabaseIfNotExists<DbMainContext>
    {
        
    }
}