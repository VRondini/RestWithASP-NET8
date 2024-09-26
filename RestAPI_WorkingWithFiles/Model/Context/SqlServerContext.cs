using Microsoft.EntityFrameworkCore;

namespace Restapi_WorkingWithFiles.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {

        }
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Books> Books { get; set; }
    }
}
