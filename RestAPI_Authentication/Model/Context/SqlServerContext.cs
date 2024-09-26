using Microsoft.EntityFrameworkCore;
using Restapi_WorkingWithFiles.Model;

namespace RestWithASPNETUdemy.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        
        }
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
