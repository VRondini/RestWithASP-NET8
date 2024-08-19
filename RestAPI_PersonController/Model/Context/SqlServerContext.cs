using Microsoft.EntityFrameworkCore;

namespace Restapi_PersonController.Model.Context
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
    }
}
